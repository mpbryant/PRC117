<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CTCSS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CTCSS))
        Me.StoredPresetsDataSet = New WindowsApplication1.StoredPresetsDataSet()
        Me.CTCSSBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CTCSSTableAdapter = New WindowsApplication1.StoredPresetsDataSetTableAdapters.CTCSSTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager()
        Me.CTCSSBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.CTCSSBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.CTCSSDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CTCSSBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CTCSSBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CTCSSBindingNavigator.SuspendLayout()
        CType(Me.CTCSSDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StoredPresetsDataSet
        '
        Me.StoredPresetsDataSet.DataSetName = "StoredPresetsDataSet"
        Me.StoredPresetsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CTCSSBindingSource
        '
        Me.CTCSSBindingSource.DataMember = "CTCSS"
        Me.CTCSSBindingSource.DataSource = Me.StoredPresetsDataSet
        '
        'CTCSSTableAdapter
        '
        Me.CTCSSTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CTCSSTableAdapter = Me.CTCSSTableAdapter
        Me.TableAdapterManager.OptionCodes25kHzTableAdapter = Nothing
        Me.TableAdapterManager.OptionCodes5kHzTableAdapter = Nothing
        Me.TableAdapterManager.PRCtrainerTableAdapter = Nothing
        Me.TableAdapterManager.SATCOMpresetsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'CTCSSBindingNavigator
        '
        Me.CTCSSBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.CTCSSBindingNavigator.BindingSource = Me.CTCSSBindingSource
        Me.CTCSSBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.CTCSSBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.CTCSSBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.CTCSSBindingNavigatorSaveItem})
        Me.CTCSSBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.CTCSSBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.CTCSSBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.CTCSSBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.CTCSSBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.CTCSSBindingNavigator.Name = "CTCSSBindingNavigator"
        Me.CTCSSBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.CTCSSBindingNavigator.Size = New System.Drawing.Size(688, 25)
        Me.CTCSSBindingNavigator.TabIndex = 0
        Me.CTCSSBindingNavigator.Text = "BindingNavigator1"
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
        'CTCSSBindingNavigatorSaveItem
        '
        Me.CTCSSBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CTCSSBindingNavigatorSaveItem.Image = CType(resources.GetObject("CTCSSBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.CTCSSBindingNavigatorSaveItem.Name = "CTCSSBindingNavigatorSaveItem"
        Me.CTCSSBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.CTCSSBindingNavigatorSaveItem.Text = "Save Data"
        '
        'CTCSSDataGridView
        '
        Me.CTCSSDataGridView.AutoGenerateColumns = False
        Me.CTCSSDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CTCSSDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.CTCSSDataGridView.DataSource = Me.CTCSSBindingSource
        Me.CTCSSDataGridView.Location = New System.Drawing.Point(73, 47)
        Me.CTCSSDataGridView.Name = "CTCSSDataGridView"
        Me.CTCSSDataGridView.Size = New System.Drawing.Size(447, 301)
        Me.CTCSSDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "index"
        Me.DataGridViewTextBoxColumn4.HeaderText = "index"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "FREQ"
        Me.DataGridViewTextBoxColumn1.HeaderText = "FREQ"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "EIA"
        Me.DataGridViewTextBoxColumn2.HeaderText = "EIA"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "HAM"
        Me.DataGridViewTextBoxColumn3.HeaderText = "HAM"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'CTCSS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 377)
        Me.Controls.Add(Me.CTCSSDataGridView)
        Me.Controls.Add(Me.CTCSSBindingNavigator)
        Me.Name = "CTCSS"
        Me.Text = "CTCSS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CTCSSBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CTCSSBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CTCSSBindingNavigator.ResumeLayout(False)
        Me.CTCSSBindingNavigator.PerformLayout()
        CType(Me.CTCSSDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StoredPresetsDataSet As WindowsApplication1.StoredPresetsDataSet
    Friend WithEvents CTCSSBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CTCSSTableAdapter As WindowsApplication1.StoredPresetsDataSetTableAdapters.CTCSSTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents CTCSSBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents CTCSSBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents CTCSSDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
