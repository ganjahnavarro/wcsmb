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

Partial Public Class customerprice
    Public Property Id As Integer
    Public Property Price As Double
    Public Property stockId As Integer
    Public Property customerId As Integer

    Public Overridable Property stock As stock
    Public Overridable Property customer As customer

End Class
