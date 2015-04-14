Public Class OptionsCodes

    Private Sub OptionCodes25kHzBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.OptionCodes25kHzBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)

    End Sub

    Private Sub OptionsCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StoredPresetsDataSet.OptionCodes5kHz' table. You can move, or remove it, as needed.
        Me.OptionCodes5kHzTableAdapter.Fill(Me.StoredPresetsDataSet.OptionCodes5kHz)
        'TODO: This line of code loads data into the 'StoredPresetsDataSet.OptionCodes25kHz' table. You can move, or remove it, as needed.
        Me.OptionCodes25kHzTableAdapter.Fill(Me.StoredPresetsDataSet.OptionCodes25kHz)

    End Sub

    
End Class