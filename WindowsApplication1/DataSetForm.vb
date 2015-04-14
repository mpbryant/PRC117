Imports System.Data.SqlClient 'import for DB connection

Public Class DataSetForm


   
    Private Sub PRCtrainerBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.PRCtrainerBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)

    End Sub

    Private Sub DataSetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StoredPresetsDataSet.PRCtrainer' table. You can move, or remove it, as needed.
        Me.PRCtrainerTableAdapter.Fill(Me.StoredPresetsDataSet.PRCtrainer)
        
    End Sub


    
    
    Private Sub PRCtrainerBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs) Handles PRCtrainerBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.PRCtrainerBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)

    End Sub

    Public Sub UpdateDB()
        Me.Validate()
        Me.PRCtrainerBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)
    End Sub

End Class