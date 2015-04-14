Public Class SatcomPresets

    Private Sub SATCOMpresetsBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles SATCOMpresetsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.SATCOMpresetsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)

    End Sub

    Private Sub SatcomPresets_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StoredPresetsDataSet.SATCOMpresets' table. You can move, or remove it, as needed.
        Me.SATCOMpresetsTableAdapter.Fill(Me.StoredPresetsDataSet.SATCOMpresets)

    End Sub

    
End Class