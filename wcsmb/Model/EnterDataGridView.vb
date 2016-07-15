﻿Imports System.Windows.Forms
Imports System.Drawing

Public Class EnterDataGridView
    Inherits DataGridView

    <System.Security.Permissions.UIPermission( _
        System.Security.Permissions.SecurityAction.LinkDemand, _
        Window:=System.Security.Permissions.UIPermissionWindow.AllWindows)> _
    Protected Overrides Function ProcessDialogKey( _
        ByVal keyData As Keys) As Boolean

        Dim key As Keys = keyData And Keys.KeyCode

        If key = Keys.Enter Then
            Return Me.ProcessTabKey(keyData)
        End If

        Return MyBase.ProcessDialogKey(keyData)
    End Function

    <System.Security.Permissions.SecurityPermission( _
        System.Security.Permissions.SecurityAction.LinkDemand, Flags:= _
        System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)> _
    Protected Overrides Function ProcessDataGridViewKey( _
        ByVal e As System.Windows.Forms.KeyEventArgs) As Boolean

        If e.KeyCode = Keys.Enter Then
            Return Me.ProcessTabKey(e.KeyData)
        End If

        Return MyBase.ProcessDataGridViewKey(e)
    End Function

End Class
