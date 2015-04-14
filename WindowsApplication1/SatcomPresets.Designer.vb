<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SatcomPresets
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SatcomPresets))
        Me.StoredPresetsDataSet = New WindowsApplication1.StoredPresetsDataSet()
        Me.SATCOMpresetsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SATCOMpresetsTableAdapter = New WindowsApplication1.StoredPresetsDataSetTableAdapters.SATCOMpresetsTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager()
        Me.SATCOMpresetsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SATCOMpresetsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.SATCOMpresetsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SATCOMpresetsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SATCOMpresetsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SATCOMpresetsBindingNavigator.SuspendLayout()
        CType(Me.SATCOMpresetsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StoredPresetsDataSet
        '
        Me.StoredPresetsDataSet.DataSetName = "StoredPresetsDataSet"
        Me.StoredPresetsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SATCOMpresetsBindingSource
        '
        Me.SATCOMpresetsBindingSource.DataMember = "SATCOMpresets"
        Me.SATCOMpresetsBindingSource.DataSource = Me.StoredPresetsDataSet
        '
        'SATCOMpresetsTableAdapter
        '
        Me.SATCOMpresetsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.OptionCodes25kHzTableAdapter = Nothing
        Me.TableAdapterManager.OptionCodes5kHzTableAdapter = Nothing
        Me.TableAdapterManager.PRCtrainerTableAdapter = Nothing
        Me.TableAdapterManager.SATCOMpresetsTableAdapter = Me.SATCOMpresetsTableAdapter
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'SATCOMpresetsBindingNavigator
        '
        Me.SATCOMpresetsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.SATCOMpresetsBindingNavigator.BindingSource = Me.SATCOMpresetsBindingSource
        Me.SATCOMpresetsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.SATCOMpresetsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.SATCOMpresetsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.SATCOMpresetsBindingNavigatorSaveItem})
        Me.SATCOMpresetsBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.SATCOMpresetsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.SATCOMpresetsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.SATCOMpresetsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.SATCOMpresetsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.SATCOMpresetsBindingNavigator.Name = "SATCOMpresetsBindingNavigator"
        Me.SATCOMpresetsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.SATCOMpresetsBindingNavigator.Size = New System.Drawing.Size(343, 25)
        Me.SATCOMpresetsBindingNavigator.TabIndex = 0
        Me.SATCOMpresetsBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(28, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 21)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'SATCOMpresetsBindingNavigatorSaveItem
        '
        Me.SATCOMpresetsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SATCOMpresetsBindingNavigatorSaveItem.Image = CType(resources.GetObject("SATCOMpresetsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.SATCOMpresetsBindingNavigatorSaveItem.Name = "SATCOMpresetsBindingNavigatorSaveItem"
        Me.SATCOMpresetsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.SATCOMpresetsBindingNavigatorSaveItem.Text = "Save Data"
        '
        'SATCOMpresetsDataGridView
        '
        Me.SATCOMpresetsDataGridView.AutoGenerateColumns = False
        Me.SATCOMpresetsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SATCOMpresetsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.SATCOMpresetsDataGridView.DataSource = Me.SATCOMpresetsBindingSource
        Me.SATCOMpresetsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SATCOMpresetsDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.SATCOMpresetsDataGridView.Name = "SATCOMpresetsDataGridView"
        Me.SATCOMpresetsDataGridView.Size = New System.Drawing.Size(343, 241)
        Me.SATCOMpresetsDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "SatcomPresetNum"
        Me.DataGridViewTextBoxColumn1.HeaderText = "SatcomPresetNum"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Uplink"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Uplink"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Downlink"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Downlink"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'SatcomPresets
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 266)
        Me.Controls.Add(Me.SATCOMpresetsDataGridView)
        Me.Controls.Add(Me.SATCOMpresetsBindingNavigator)
        Me.Name = "SatcomPresets"
        Me.Text = "SatcomPresets"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SATCOMpresetsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SATCOMpresetsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SATCOMpresetsBindingNavigator.ResumeLayout(False)
        Me.SATCOMpresetsBindingNavigator.PerformLayout()
        CType(Me.SATCOMpresetsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StoredPresetsDataSet As WindowsApplication1.StoredPresetsDataSet
    Friend WithEvents SATCOMpresetsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SATCOMpresetsTableAdapter As WindowsApplication1.StoredPresetsDataSetTableAdapters.SATCOMpresetsTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents SATCOMpresetsBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SATCOMpresetsBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents SATCOMpresetsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
