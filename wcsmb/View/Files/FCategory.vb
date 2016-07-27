﻿Public Class FCategory
    Implements IControl

    Dim currentObject As category

    Private Sub postConstruct(sender As Object, e As EventArgs) Handles MyBase.Load
        displayList(Util.getCategoryNames)
        initialize()
        selectFirstAndLoad()
    End Sub

    Private Sub selectFirstAndLoad()
        If Not IsNothing(box.Items) And box.Items.Count > 0 Then
            box.ClearSelected()
            box.SelectedIndex = 0
            selectedItemChanged()
        End If
    End Sub

    Private Sub selectedItemChanged()
        findAndLoad(Util.removeBullet(box.SelectedItem))
        enableInputs(False)
        showUpdateButtons(False)
        Controller.updateMode = Nothing
    End Sub

#Region "Standard"
    Protected Overloads Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        Select Case keyData
            Case Keys.Enter
                If tbLast.Focused Then
                    checkClick()
                Else
                    Return MyBase.ProcessDialogKey(Keys.Tab)
                End If
        End Select
        Return MyBase.ProcessDialogKey(keyData)
    End Function

    Private Sub initialize()
        Me.reset()
        Me.loadObject()
        Me.enableInputs(False)
        Me.showUpdateButtons(False)
        Controller.updateMode = Nothing
    End Sub

    Public Sub addClick() Handles btnAdd.Click
        If Not IsNothing(Me) And btnAdd.Visible Then
            Me.reset()
            Me.enableInputs(True)
            Controller.updateMode = Constants.UPDATE_MODE_CREATE
            showUpdateButtons(True)
        End If
    End Sub

    Public Sub editClick() Handles btnEdit.Click
        If Not IsNothing(Me) And btnEdit.Visible Then
            Me.enableInputs(True)
            Controller.updateMode = Constants.UPDATE_MODE_EDIT
            Me.loadObject()
            showUpdateButtons(True)
        End If
    End Sub

    Public Sub deleteClick() Handles btnDelete.Click
        If Not IsNothing(Me) And btnDelete.Visible Then
            If Util.askForConfirmation("Delete this item?", "Delete") Then
                Me.deleteObject()
                Me.resetListSelection()
                resetMe()
            End If
        End If
    End Sub

    Public Sub cancelClick() Handles btnCancel.Click
        If Not IsNothing(Me) And btnCancel.Visible Then
            resetMe()
        End If
    End Sub

    Public Sub checkClick() Handles btnCheck.Click
        If Not IsNothing(Me) And btnCheck.Visible Then
            If Not IsNothing(Me.getErrorMessage) Then
                Util.notifyError(Me.getErrorMessage)
            Else
                Try
                    saveChangesOnMe()
                    resetMe()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub saveChangesOnMe()
        If Controller.updateMode = Constants.UPDATE_MODE_CREATE Then
            Me.saveObject()
        Else
            Me.updateObject()
        End If
    End Sub

    Private Sub resetMe()
        Me.reset()
        Me.enableInputs(False)
        showUpdateButtons(False)
        Controller.updateMode = Nothing
        Me.loadObject()
    End Sub

    Public Sub showUpdateButtons(ByVal show As Boolean)
        btnCheck.Visible = show
        btnCancel.Visible = show

        btnAdd.Visible = Not show
        btnEdit.Visible = Not show
        btnDelete.Visible = Not show
    End Sub

#End Region

    Public Sub deleteObject() Implements IControl.deleteObject
        Using context As New DatabaseContext()
            currentObject = context.categories.Where(Function(c) _
                c.Id.Equals(currentObject.Id)).FirstOrDefault
            currentObject.Active = False

            Dim action As String = Controller.currentUser.Username & " deleted a category (" &
                currentObject.Name & ")"
            context.activities.Add(New activity(action))

            context.SaveChanges()
        End Using

        'trash
        Using context As New DatabaseContext()
            Dim trashAction = "update categories set active = false where name = ''" & currentObject.Name & "''" &
                " and modifydate <= ''" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "''"
            context.Database.ExecuteSqlCommand("insert into trash(date, action) values(current_date, '" & trashAction & "')")
        End Using
    End Sub

    Public Sub deleteRow() Implements IControl.deleteRow
    End Sub

    Public Function getAllowEditDelete() As Boolean Implements IControl.getAllowEditDelete
        Return True
    End Function

    Public Sub enableInputs(enable As Boolean) Implements IControl.enableInputs
        tbLast.Enabled = enable

        If enable Then
            tbLast.Focus()
        End If
    End Sub

    Public Sub loadObject() Implements IControl.loadObject
        If Not IsNothing(currentObject) Then
            loadCurrentObject()
        Else
            Using context As New DatabaseContext()
                currentObject = context.categories _
                    .Where(Function(c) c.Active = True) _
                    .OrderBy(Function(c) c.Name) _
                    .FirstOrDefault()
            End Using

            If Not IsNothing(currentObject) Then
                loadCurrentObject()
            Else
                reset()
            End If
        End If
    End Sub

    Private Sub loadCurrentObject()
        lblBy.Text = Util.fmtModifyBy(currentObject.ModifyBy)
        lblOn.Text = Util.fmtModifyDate(currentObject.ModifyDate)
        tbLast.Text = currentObject.Name
    End Sub

    Public Sub nextObject() Implements IControl.nextObject
    End Sub

    Public Sub previousObject() Implements IControl.previousObject
    End Sub

    Public Sub reset() Implements IControl.reset
        lblBy.Text = String.Empty
        lblOn.Text = String.Empty
        tbSearch.Text = String.Empty
        tbLast.Text = String.Empty
    End Sub

    Public Sub saveObject() Implements IControl.saveObject
        Using context As New DatabaseContext()
            currentObject = New category
            setObjectValues()
            context.categories.Add(currentObject)

            Dim action As String = Controller.currentUser.Username & " added a category (" &
                currentObject.Name & ")"
            context.activities.Add(New activity(action))

            context.SaveChanges()
            Util.notifyInfo("Added 1 Category.")
        End Using
    End Sub

    Public Sub search() Implements IControl.search
        tbSearch.Focus()
    End Sub

    Public Sub setObjectValues()
        currentObject.Name = tbLast.Text
        currentObject.ModifyDate = DateTime.Now
        currentObject.ModifyBy = Controller.currentUser.Username
        currentObject.Active = True
    End Sub

    Public Function showAllButtons() As Integer Implements IControl.getButtonsShown
        Return Constants.SHOW_ACTION
    End Function

    Public Sub updateObject() Implements IControl.updateObject
        Using context As New DatabaseContext()
            currentObject = context.categories.Where(Function(c) _
                c.Id.Equals(currentObject.Id)).FirstOrDefault
            setObjectValues()

            Dim action As String = Controller.currentUser.Username & " updated a category (" &
                currentObject.Name & ")"
            context.activities.Add(New activity(action))

            context.SaveChanges()
            Util.notifyInfo("Updated 1 Category")
        End Using
    End Sub

    Public Function getErrorMessage() As String Implements IControl.getErrorMessage
        If String.IsNullOrWhiteSpace(tbLast.Text) Then
            Return "Category name is required."
        End If

        If Controller.updateMode.Equals(Constants.UPDATE_MODE_CREATE) _
            OrElse Not currentObject.Name.ToUpper.Equals(tbLast.Text.ToUpper) Then
            Using context As New DatabaseContext()
                'c.Active = True AndAlso 
                Dim duplicate = context.categories _
                    .Where(Function(c) c.Name.ToUpper.Equals(tbLast.Text.ToUpper)) _
                    .FirstOrDefault

                If Not IsNothing(duplicate) Then
                    Return "Category name already exists."
                End If
            End Using
        End If

        Return Nothing
    End Function

    Private Sub displayList(ByVal list As List(Of String))
        box.Items.Clear()
        For Each cName In list
            box.Items.Add(Util.addBullet(cName))
        Next
    End Sub

    Private Sub findAndLoad(ByVal name As String)
        If Not IsNothing(name) Then
            findObjectByName(name)
            loadObject()
        End If
    End Sub

    Private Sub findObjectByName(ByVal name As String)
        Using context = New DatabaseContext()
            currentObject = context.categories.Where(Function(c) c.Name.Equals(name) And c.Active = True).FirstOrDefault
        End Using
    End Sub

    Private Sub boxChanged(sender As Object, e As EventArgs) Handles box.SelectedIndexChanged
        selectedItemChanged()
    End Sub

    Public Sub resetListSelection() Implements IControl.resetListSelection
        tbSearch.Clear()
        currentObject = Nothing
        displayList(Util.getCategoryNames)
    End Sub

    Private Sub tbSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tbSearch.KeyDown
        If e.KeyCode = Keys.Down Then
            box.Focus()
            SendKeys.Send("{DOWN}")
        End If
    End Sub

    Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
        If tbSearch.Text = String.Empty Then
            displayList(Util.getCategoryNames)
        Else
            Using context = New DatabaseContext()
                displayList(context.categories _
                    .Where(Function(c) c.Active = True And c.Name.ToLower _
                        .Contains(tbSearch.Text.ToLower)) _
                    .OrderBy(Function(c) c.Name) _
                    .Select(Function(c) c.Name) _
                    .ToList())
                selectFirstAndLoad()
            End Using
        End If
    End Sub

    Public Sub firstObject() Implements IControl.firstObject
    End Sub

    Public Sub lastObject() Implements IControl.lastObject
    End Sub

    Public Sub printObject() Implements IControl.printObject
    End Sub

End Class