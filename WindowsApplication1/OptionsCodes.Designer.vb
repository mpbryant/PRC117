<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsCodes
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
        Me.OptionCodes25kHzDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OptionCodes25kHzBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StoredPresetsDataSet = New WindowsApplication1.StoredPresetsDataSet()
        Me.OptionCodes5kHzDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OptionCodes5kHzBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OptionCodes25kHzTableAdapter = New WindowsApplication1.StoredPresetsDataSetTableAdapters.OptionCodes25kHzTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager()
        Me.OptionCodes5kHzTableAdapter = New WindowsApplication1.StoredPresetsDataSetTableAdapters.OptionCodes5kHzTableAdapter()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.OptionCodes25kHzDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionCodes25kHzBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionCodes5kHzDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OptionCodes5kHzBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OptionCodes25kHzDataGridView
        '
        Me.OptionCodes25kHzDataGridView.AutoGenerateColumns = False
        Me.OptionCodes25kHzDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OptionCodes25kHzDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.OptionCodes25kHzDataGridView.DataSource = Me.OptionCodes25kHzBindingSource
        Me.OptionCodes25kHzDataGridView.Location = New System.Drawing.Point(12, 25)
        Me.OptionCodes25kHzDataGridView.Name = "OptionCodes25kHzDataGridView"
        Me.OptionCodes25kHzDataGridView.Size = New System.Drawing.Size(744, 220)
        Me.OptionCodes25kHzDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "OptionCode"
        Me.DataGridViewTextBoxColumn1.HeaderText = "OptionCode"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "IOdataRate"
        Me.DataGridViewTextBoxColumn2.HeaderText = "IOdataRate"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ModulationType"
        Me.DataGridViewTextBoxColumn3.HeaderText = "ModulationType"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "KG84Compliant"
        Me.DataGridViewTextBoxColumn4.HeaderText = "KG84Compliant"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "VinsonCompliant"
        Me.DataGridViewTextBoxColumn5.HeaderText = "VinsonCompliant"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "FascinatorCompliant"
        Me.DataGridViewTextBoxColumn6.HeaderText = "FascinatorCompliant"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "ForwardErrorCorrection"
        Me.DataGridViewTextBoxColumn7.HeaderText = "ForwardErrorCorrection"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'OptionCodes25kHzBindingSource
        '
        Me.OptionCodes25kHzBindingSource.DataMember = "OptionCodes25kHz"
        Me.OptionCodes25kHzBindingSource.DataSource = Me.StoredPresetsDataSet
        '
        'StoredPresetsDataSet
        '
        Me.StoredPresetsDataSet.DataSetName = "StoredPresetsDataSet"
        Me.StoredPresetsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'OptionCodes5kHzDataGridView
        '
        Me.OptionCodes5kHzDataGridView.AutoGenerateColumns = False
        Me.OptionCodes5kHzDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OptionCodes5kHzDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13})
        Me.OptionCodes5kHzDataGridView.DataSource = Me.OptionCodes5kHzBindingSource
        Me.OptionCodes5kHzDataGridView.Location = New System.Drawing.Point(12, 284)
        Me.OptionCodes5kHzDataGridView.Name = "OptionCodes5kHzDataGridView"
        Me.OptionCodes5kHzDataGridView.Size = New System.Drawing.Size(643, 220)
        Me.OptionCodes5kHzDataGridView.TabIndex = 2
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "OptionCode"
        Me.DataGridViewTextBoxColumn8.HeaderText = "OptionCode"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "IOdataRate"
        Me.DataGridViewTextBoxColumn9.HeaderText = "IOdataRate"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "ModulationType"
        Me.DataGridViewTextBoxColumn10.HeaderText = "ModulationType"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "KG84Compliant"
        Me.DataGridViewTextBoxColumn11.HeaderText = "KG84Compliant"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "ANDVTcompliant"
        Me.DataGridViewTextBoxColumn12.HeaderText = "ANDVTcompliant"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "ForwardErrorCorrection"
        Me.DataGridViewTextBoxColumn13.HeaderText = "ForwardErrorCorrection"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'OptionCodes5kHzBindingSource
        '
        Me.OptionCodes5kHzBindingSource.DataMember = "OptionCodes5kHz"
        Me.OptionCodes5kHzBindingSource.DataSource = Me.StoredPresetsDataSet
        '
        'OptionCodes25kHzTableAdapter
        '
        Me.OptionCodes25kHzTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.OptionCodes25kHzTableAdapter = Me.OptionCodes25kHzTableAdapter
        Me.TableAdapterManager.OptionCodes5kHzTableAdapter = Me.OptionCodes5kHzTableAdapter
        Me.TableAdapterManager.PRCtrainerTableAdapter = Nothing
        Me.TableAdapterManager.SATCOMpresetsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'OptionCodes5kHzTableAdapter
        '
        Me.OptionCodes5kHzTableAdapter.ClearBeforeFill = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "25 kHz Option Codes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 257)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "5 kHz Option Codes"
        '
        'OptionsCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 516)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OptionCodes5kHzDataGridView)
        Me.Controls.Add(Me.OptionCodes25kHzDataGridView)
        Me.Name = "OptionsCodes"
        Me.Text = "OptionsCodes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.OptionCodes25kHzDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionCodes25kHzBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionCodes5kHzDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OptionCodes5kHzBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StoredPresetsDataSet As WindowsApplication1.StoredPresetsDataSet
    Friend WithEvents OptionCodes25kHzBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OptionCodes25kHzTableAdapter As WindowsApplication1.StoredPresetsDataSetTableAdapters.OptionCodes25kHzTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents OptionCodes25kHzDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OptionCodes5kHzTableAdapter As WindowsApplication1.StoredPresetsDataSetTableAdapters.OptionCodes5kHzTableAdapter
    Friend WithEvents OptionCodes5kHzBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents OptionCodes5kHzDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
