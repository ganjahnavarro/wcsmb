'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class customercollection
    Public Property Id As Integer
    Public Property [Date] As Date
    Public Property PostedDate As Nullable(Of Date)
    Public Property Remarks As String
    Public Property TotalCheck As Double
    Public Property TotalPaid As Double
    Public Property ModifyBy As String
    Public Property ModifyDate As Date
    Public Property customerId As Integer
    Public Property Bank As String
    Public Property DocumentNo As String

    Public Overridable Property collectioncheckitems As ICollection(Of collectioncheckitem) = New HashSet(Of collectioncheckitem)
    Public Overridable Property collectionorderitems As ICollection(Of collectionorderitem) = New HashSet(Of collectionorderitem)
    Public Overridable Property customer As customer

End Class