Imports System.Data.SqlClient 'import for DB connection

Public Class MyGlobalData

    Private Sub GlobalSavedItemsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles GlobalSavedItemsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.GlobalSavedItemsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)

    End Sub

    Private Sub MyGlobalData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StoredPresetsDataSet.GlobalSavedItems' table. You can move, or remove it, as needed.
        Me.GlobalSavedItemsTableAdapter.Fill(Me.StoredPresetsDataSet.GlobalSavedItems)

    End Sub

    Public Sub UpdateDB()
        Me.Validate()
        Me.GlobalSavedItemsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)
    End Sub

    'Public Sub UpdateDB()
    '    Me.Validate()
    '    Me.PRCtrainerBindingSource.EndEdit()
    '    Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)
    'End Sub

End Class