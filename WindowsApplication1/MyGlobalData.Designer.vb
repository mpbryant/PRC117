<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyGlobalData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyGlobalData))
        Me.StoredPresetsDataSet = New WindowsApplication1.StoredPresetsDataSet()
        Me.GlobalSavedItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GlobalSavedItemsTableAdapter = New WindowsApplication1.StoredPresetsDataSetTableAdapters.GlobalSavedItemsTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager()
        Me.GlobalSavedItemsBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.GlobalSavedItemsBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.GlobalSavedItemsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GlobalSavedItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GlobalSavedItemsBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GlobalSavedItemsBindingNavigator.SuspendLayout()
        CType(Me.GlobalSavedItemsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StoredPresetsDataSet
        '
        Me.StoredPresetsDataSet.DataSetName = "StoredPresetsDataSet"
        Me.StoredPresetsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GlobalSavedItemsBindingSource
        '
        Me.GlobalSavedItemsBindingSource.DataMember = "GlobalSavedItems"
        Me.GlobalSavedItemsBindingSource.DataSource = Me.StoredPresetsDataSet
        '
        'GlobalSavedItemsTableAdapter
        '
        Me.GlobalSavedItemsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CTCSSTableAdapter = Nothing
        Me.TableAdapterManager.GlobalSavedItemsTableAdapter = Me.GlobalSavedItemsTableAdapter
        Me.TableAdapterManager.OptionCodes25kHzTableAdapter = Nothing
        Me.TableAdapterManager.OptionCodes5kHzTableAdapter = Nothing
        Me.TableAdapterManager.PRCtrainerTableAdapter = Nothing
        Me.TableAdapterManager.SATCOMpresetsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'GlobalSavedItemsBindingNavigator
        '
        Me.GlobalSavedItemsBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.GlobalSavedItemsBindingNavigator.BindingSource = Me.GlobalSavedItemsBindingSource
        Me.GlobalSavedItemsBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.GlobalSavedItemsBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.GlobalSavedItemsBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.GlobalSavedItemsBindingNavigatorSaveItem})
        Me.GlobalSavedItemsBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.GlobalSavedItemsBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.GlobalSavedItemsBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.GlobalSavedItemsBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.GlobalSavedItemsBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.GlobalSavedItemsBindingNavigator.Name = "GlobalSavedItemsBindingNavigator"
        Me.GlobalSavedItemsBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.GlobalSavedItemsBindingNavigator.Size = New System.Drawing.Size(846, 25)
        Me.GlobalSavedItemsBindingNavigator.TabIndex = 0
        Me.GlobalSavedItemsBindingNavigator.Text = "BindingNavigator1"
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
        'GlobalSavedItemsBindingNavigatorSaveItem
        '
        Me.GlobalSavedItemsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.GlobalSavedItemsBindingNavigatorSaveItem.Image = CType(resources.GetObject("GlobalSavedItemsBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.GlobalSavedItemsBindingNavigatorSaveItem.Name = "GlobalSavedItemsBindingNavigatorSaveItem"
        Me.GlobalSavedItemsBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.GlobalSavedItemsBindingNavigatorSaveItem.Text = "Save Data"
        '
        'GlobalSavedItemsDataGridView
        '
        Me.GlobalSavedItemsDataGridView.AutoGenerateColumns = False
        Me.GlobalSavedItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GlobalSavedItemsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8})
        Me.GlobalSavedItemsDataGridView.DataSource = Me.GlobalSavedItemsBindingSource
        Me.GlobalSavedItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GlobalSavedItemsDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.GlobalSavedItemsDataGridView.Name = "GlobalSavedItemsDataGridView"
        Me.GlobalSavedItemsDataGridView.Size = New System.Drawing.Size(846, 305)
        Me.GlobalSavedItemsDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Id"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Id"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "GlobalEnableScan"
        Me.DataGridViewTextBoxColumn2.HeaderText = "GlobalEnableScan"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "GlobalPriorityTx"
        Me.DataGridViewTextBoxColumn3.HeaderText = "GlobalPriorityTx"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "GlobalPriorityRxEnable"
        Me.DataGridViewTextBoxColumn4.HeaderText = "GlobalPriorityRxEnable"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "GlobalPriorityRx"
        Me.DataGridViewTextBoxColumn5.HeaderText = "GlobalPriorityRx"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "GlobalHangTime"
        Me.DataGridViewTextBoxColumn6.HeaderText = "GlobalHangTime"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "GlobalEnableHoldTime"
        Me.DataGridViewTextBoxColumn7.HeaderText = "GlobalEnableHoldTime"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "GlobalHoldTimeDuration"
        Me.DataGridViewTextBoxColumn8.HeaderText = "GlobalHoldTimeDuration"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'MyGlobalData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(846, 330)
        Me.Controls.Add(Me.GlobalSavedItemsDataGridView)
        Me.Controls.Add(Me.GlobalSavedItemsBindingNavigator)
        Me.Name = "MyGlobalData"
        Me.Text = "MyGlobalData"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GlobalSavedItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GlobalSavedItemsBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GlobalSavedItemsBindingNavigator.ResumeLayout(False)
        Me.GlobalSavedItemsBindingNavigator.PerformLayout()
        CType(Me.GlobalSavedItemsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StoredPresetsDataSet As WindowsApplication1.StoredPresetsDataSet
    Friend WithEvents GlobalSavedItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GlobalSavedItemsTableAdapter As WindowsApplication1.StoredPresetsDataSetTableAdapters.GlobalSavedItemsTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents GlobalSavedItemsBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents GlobalSavedItemsBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents GlobalSavedItemsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
