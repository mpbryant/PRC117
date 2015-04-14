Public Class CTCSS

    Private Sub CTCSSBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.CTCSSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)

    End Sub

    Private Sub CTCSS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'StoredPresetsDataSet.CTCSS' table. You can move, or remove it, as needed.
        Me.CTCSSTableAdapter.Fill(Me.StoredPresetsDataSet.CTCSS)
        'TODO: This line of code loads data into the 'StoredPresetsDataSet.CTCSS' table. You can move, or remove it, as needed.
        Me.CTCSSTableAdapter.Fill(Me.StoredPresetsDataSet.CTCSS)

    End Sub

    Private Sub CTCSSBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs) Handles CTCSSBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CTCSSBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.StoredPresetsDataSet)

    End Sub
End Class