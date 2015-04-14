<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataSetForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataSetForm))
        Me.PRCtrainerBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.PRCtrainerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.StoredPresetsDataSet = New WindowsApplication1.StoredPresetsDataSet()
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
        Me.PRCtrainerBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.PRCtrainerDataGridView = New System.Windows.Forms.DataGridView()
        Me.PRCtrainerTableAdapter = New WindowsApplication1.StoredPresetsDataSetTableAdapters.PRCtrainerTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetCryptoMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetCryptoKey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetSatcomChannel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetDataMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetFascinatorMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetAESMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetKG84Mode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetANDVTframes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetRXfade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetANDVTautoswitch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetKeySource = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetCodebook = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetDeviation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetOptMod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetTXPower = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetTXpowerDown = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetManualSquelchSetting = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetCTCSS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetRxSquelch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetCTCSSuserEntry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetCTCSSrxUserEntry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetCTCSSrx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetChannelBusyPriority = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetCDCSStxCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetCDCSSrxCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetVinsonCompatibility = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetBeaconFreq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetBeaconMod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetBeaconTxDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetBeaconOffDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetBeaconTxPower = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetSpare = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PresetInScanList = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PRCtrainerBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PRCtrainerBindingNavigator.SuspendLayout()
        CType(Me.PRCtrainerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PRCtrainerDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PRCtrainerBindingNavigator
        '
        Me.PRCtrainerBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.PRCtrainerBindingNavigator.BindingSource = Me.PRCtrainerBindingSource
        Me.PRCtrainerBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.PRCtrainerBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.PRCtrainerBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.PRCtrainerBindingNavigatorSaveItem})
        Me.PRCtrainerBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.PRCtrainerBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.PRCtrainerBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.PRCtrainerBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.PRCtrainerBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.PRCtrainerBindingNavigator.Name = "PRCtrainerBindingNavigator"
        Me.PRCtrainerBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.PRCtrainerBindingNavigator.Size = New System.Drawing.Size(803, 25)
        Me.PRCtrainerBindingNavigator.TabIndex = 0
        Me.PRCtrainerBindingNavigator.Text = "BindingNavigator1"
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
        'PRCtrainerBindingSource
        '
        Me.PRCtrainerBindingSource.DataMember = "PRCtrainer"
        Me.PRCtrainerBindingSource.DataSource = Me.StoredPresetsDataSet
        '
        'StoredPresetsDataSet
        '
        Me.StoredPresetsDataSet.DataSetName = "StoredPresetsDataSet"
        Me.StoredPresetsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        'PRCtrainerBindingNavigatorSaveItem
        '
        Me.PRCtrainerBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PRCtrainerBindingNavigatorSaveItem.Image = CType(resources.GetObject("PRCtrainerBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.PRCtrainerBindingNavigatorSaveItem.Name = "PRCtrainerBindingNavigatorSaveItem"
        Me.PRCtrainerBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.PRCtrainerBindingNavigatorSaveItem.Text = "Save Data"
        '
        'PRCtrainerDataGridView
        '
        Me.PRCtrainerDataGridView.AutoGenerateColumns = False
        Me.PRCtrainerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PRCtrainerDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.PresetCryptoMode, Me.PresetCryptoKey, Me.PresetSatcomChannel, Me.PresetDataMode, Me.PresetFascinatorMode, Me.PresetAESMode, Me.PresetKG84Mode, Me.PresetANDVTframes, Me.PresetRXfade, Me.PresetANDVTautoswitch, Me.PresetKeySource, Me.PresetCodebook, Me.PresetDeviation, Me.PresetOptMod, Me.PresetTXPower, Me.PresetTXpowerDown, Me.PresetManualSquelchSetting, Me.PresetCTCSS, Me.PresetRxSquelch, Me.PresetCTCSSuserEntry, Me.PresetCTCSSrxUserEntry, Me.PresetCTCSSrx, Me.PresetChannelBusyPriority, Me.PresetCDCSStxCode, Me.PresetCDCSSrxCode, Me.PresetVinsonCompatibility, Me.PresetBeaconFreq, Me.PresetBeaconMod, Me.PresetBeaconTxDuration, Me.PresetBeaconOffDuration, Me.PresetBeaconTxPower, Me.PresetSpare, Me.PresetInScanList})
        Me.PRCtrainerDataGridView.DataSource = Me.PRCtrainerBindingSource
        Me.PRCtrainerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PRCtrainerDataGridView.Location = New System.Drawing.Point(0, 25)
        Me.PRCtrainerDataGridView.Name = "PRCtrainerDataGridView"
        Me.PRCtrainerDataGridView.Size = New System.Drawing.Size(803, 433)
        Me.PRCtrainerDataGridView.TabIndex = 1
        '
        'PRCtrainerTableAdapter
        '
        Me.PRCtrainerTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CTCSSTableAdapter = Nothing
        Me.TableAdapterManager.GlobalSavedItemsTableAdapter = Nothing
        Me.TableAdapterManager.OptionCodes25kHzTableAdapter = Nothing
        Me.TableAdapterManager.OptionCodes5kHzTableAdapter = Nothing
        Me.TableAdapterManager.PRCtrainerTableAdapter = Me.PRCtrainerTableAdapter
        Me.TableAdapterManager.SATCOMpresetsTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "PresetNumber"
        Me.DataGridViewTextBoxColumn1.HeaderText = "PresetNumber"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PresetName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "PresetName"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "PresetType"
        Me.DataGridViewTextBoxColumn3.HeaderText = "PresetType"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "PresetTraffic"
        Me.DataGridViewTextBoxColumn4.HeaderText = "PresetTraffic"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "PresetModulation"
        Me.DataGridViewTextBoxColumn5.HeaderText = "PresetModulation"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "PresetDescription"
        Me.DataGridViewTextBoxColumn6.HeaderText = "PresetDescription"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PresetRXfreq"
        Me.DataGridViewTextBoxColumn7.HeaderText = "PresetRXfreq"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "PresetTXfreq"
        Me.DataGridViewTextBoxColumn8.HeaderText = "PresetTXfreq"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "PresetWaveform"
        Me.DataGridViewTextBoxColumn9.HeaderText = "PresetWaveform"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "PresetChannel"
        Me.DataGridViewTextBoxColumn10.HeaderText = "PresetChannel"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "PresetKey"
        Me.DataGridViewTextBoxColumn11.HeaderText = "PresetKey"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "PresetOptionCode"
        Me.DataGridViewTextBoxColumn12.HeaderText = "PresetOptionCode"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "PresetBandwidth"
        Me.DataGridViewTextBoxColumn13.HeaderText = "PresetBandwidth"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "PresetBPSrate"
        Me.DataGridViewTextBoxColumn14.HeaderText = "PresetBPSrate"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "PresetVoiceMode"
        Me.DataGridViewTextBoxColumn15.HeaderText = "PresetVoiceMode"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "PresetInterleaveDepth"
        Me.DataGridViewTextBoxColumn16.HeaderText = "PresetInterleaveDepth"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "PresetFWDerrorCorrection"
        Me.DataGridViewTextBoxColumn17.HeaderText = "PresetFWDerrorCorrection"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "PresetSquelch"
        Me.DataGridViewTextBoxColumn18.HeaderText = "PresetSquelch"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'PresetCryptoMode
        '
        Me.PresetCryptoMode.DataPropertyName = "PresetCryptoMode"
        Me.PresetCryptoMode.HeaderText = "PresetCryptoMode"
        Me.PresetCryptoMode.Name = "PresetCryptoMode"
        '
        'PresetCryptoKey
        '
        Me.PresetCryptoKey.DataPropertyName = "PresetCryptoKey"
        Me.PresetCryptoKey.HeaderText = "PresetCryptoKey"
        Me.PresetCryptoKey.Name = "PresetCryptoKey"
        '
        'PresetSatcomChannel
        '
        Me.PresetSatcomChannel.DataPropertyName = "PresetSatcomChannel"
        Me.PresetSatcomChannel.HeaderText = "PresetSatcomChannel"
        Me.PresetSatcomChannel.Name = "PresetSatcomChannel"
        '
        'PresetDataMode
        '
        Me.PresetDataMode.DataPropertyName = "PresetDataMode"
        Me.PresetDataMode.HeaderText = "PresetDataMode"
        Me.PresetDataMode.Name = "PresetDataMode"
        '
        'PresetFascinatorMode
        '
        Me.PresetFascinatorMode.DataPropertyName = "PresetFascinatorMode"
        Me.PresetFascinatorMode.HeaderText = "PresetFascinatorMode"
        Me.PresetFascinatorMode.Name = "PresetFascinatorMode"
        '
        'PresetAESMode
        '
        Me.PresetAESMode.DataPropertyName = "PresetAESMode"
        Me.PresetAESMode.HeaderText = "PresetAESMode"
        Me.PresetAESMode.Name = "PresetAESMode"
        '
        'PresetKG84Mode
        '
        Me.PresetKG84Mode.DataPropertyName = "PresetKG84Mode"
        Me.PresetKG84Mode.HeaderText = "PresetKG84Mode"
        Me.PresetKG84Mode.Name = "PresetKG84Mode"
        '
        'PresetANDVTframes
        '
        Me.PresetANDVTframes.DataPropertyName = "PresetANDVTframes"
        Me.PresetANDVTframes.HeaderText = "PresetANDVTframes"
        Me.PresetANDVTframes.Name = "PresetANDVTframes"
        '
        'PresetRXfade
        '
        Me.PresetRXfade.DataPropertyName = "PresetRXfade"
        Me.PresetRXfade.HeaderText = "PresetRXfade"
        Me.PresetRXfade.Name = "PresetRXfade"
        '
        'PresetANDVTautoswitch
        '
        Me.PresetANDVTautoswitch.DataPropertyName = "PresetANDVTautoswitch"
        Me.PresetANDVTautoswitch.HeaderText = "PresetANDVTautoswitch"
        Me.PresetANDVTautoswitch.Name = "PresetANDVTautoswitch"
        '
        'PresetKeySource
        '
        Me.PresetKeySource.DataPropertyName = "PresetKeySource"
        Me.PresetKeySource.HeaderText = "PresetKeySource"
        Me.PresetKeySource.Name = "PresetKeySource"
        '
        'PresetCodebook
        '
        Me.PresetCodebook.DataPropertyName = "PresetCodebook"
        Me.PresetCodebook.HeaderText = "PresetCodebook"
        Me.PresetCodebook.Name = "PresetCodebook"
        '
        'PresetDeviation
        '
        Me.PresetDeviation.DataPropertyName = "PresetDeviation"
        Me.PresetDeviation.HeaderText = "PresetDeviation"
        Me.PresetDeviation.Name = "PresetDeviation"
        '
        'PresetOptMod
        '
        Me.PresetOptMod.DataPropertyName = "PresetOptMod"
        Me.PresetOptMod.HeaderText = "PresetOptMod"
        Me.PresetOptMod.Name = "PresetOptMod"
        '
        'PresetTXPower
        '
        Me.PresetTXPower.DataPropertyName = "PresetTXPower"
        Me.PresetTXPower.HeaderText = "PresetTXPower"
        Me.PresetTXPower.Name = "PresetTXPower"
        '
        'PresetTXpowerDown
        '
        Me.PresetTXpowerDown.DataPropertyName = "PresetTXpowerDown"
        Me.PresetTXpowerDown.HeaderText = "PresetTXpowerDown"
        Me.PresetTXpowerDown.Name = "PresetTXpowerDown"
        '
        'PresetManualSquelchSetting
        '
        Me.PresetManualSquelchSetting.DataPropertyName = "PresetManualSquelchSetting"
        Me.PresetManualSquelchSetting.HeaderText = "PresetManualSquelchSetting"
        Me.PresetManualSquelchSetting.Name = "PresetManualSquelchSetting"
        '
        'PresetCTCSS
        '
        Me.PresetCTCSS.DataPropertyName = "PresetCTCSS"
        Me.PresetCTCSS.HeaderText = "PresetCTCSS"
        Me.PresetCTCSS.Name = "PresetCTCSS"
        '
        'PresetRxSquelch
        '
        Me.PresetRxSquelch.DataPropertyName = "PresetRxSquelch"
        Me.PresetRxSquelch.HeaderText = "PresetRxSquelch"
        Me.PresetRxSquelch.Name = "PresetRxSquelch"
        '
        'PresetCTCSSuserEntry
        '
        Me.PresetCTCSSuserEntry.DataPropertyName = "PresetCTCSSuserEntry"
        Me.PresetCTCSSuserEntry.HeaderText = "PresetCTCSSuserEntry"
        Me.PresetCTCSSuserEntry.Name = "PresetCTCSSuserEntry"
        '
        'PresetCTCSSrxUserEntry
        '
        Me.PresetCTCSSrxUserEntry.DataPropertyName = "PresetCTCSSrxUserEntry"
        Me.PresetCTCSSrxUserEntry.HeaderText = "PresetCTCSSrxUserEntry"
        Me.PresetCTCSSrxUserEntry.Name = "PresetCTCSSrxUserEntry"
        '
        'PresetCTCSSrx
        '
        Me.PresetCTCSSrx.DataPropertyName = "PresetCTCSSrx"
        Me.PresetCTCSSrx.HeaderText = "PresetCTCSSrx"
        Me.PresetCTCSSrx.Name = "PresetCTCSSrx"
        '
        'PresetChannelBusyPriority
        '
        Me.PresetChannelBusyPriority.DataPropertyName = "PresetChannelBusyPriority"
        Me.PresetChannelBusyPriority.HeaderText = "PresetChannelBusyPriority"
        Me.PresetChannelBusyPriority.Name = "PresetChannelBusyPriority"
        '
        'PresetCDCSStxCode
        '
        Me.PresetCDCSStxCode.DataPropertyName = "PresetCDCSStxCode"
        Me.PresetCDCSStxCode.HeaderText = "PresetCDCSStxCode"
        Me.PresetCDCSStxCode.Name = "PresetCDCSStxCode"
        '
        'PresetCDCSSrxCode
        '
        Me.PresetCDCSSrxCode.DataPropertyName = "PresetCDCSSrxCode"
        Me.PresetCDCSSrxCode.HeaderText = "PresetCDCSSrxCode"
        Me.PresetCDCSSrxCode.Name = "PresetCDCSSrxCode"
        '
        'PresetVinsonCompatibility
        '
        Me.PresetVinsonCompatibility.DataPropertyName = "PresetVinsonCompatibility"
        Me.PresetVinsonCompatibility.HeaderText = "PresetVinsonCompatibility"
        Me.PresetVinsonCompatibility.Name = "PresetVinsonCompatibility"
        '
        'PresetBeaconFreq
        '
        Me.PresetBeaconFreq.DataPropertyName = "PresetBeaconFreq"
        Me.PresetBeaconFreq.HeaderText = "PresetBeaconFreq"
        Me.PresetBeaconFreq.Name = "PresetBeaconFreq"
        '
        'PresetBeaconMod
        '
        Me.PresetBeaconMod.DataPropertyName = "PresetBeaconMod"
        Me.PresetBeaconMod.HeaderText = "PresetBeaconMod"
        Me.PresetBeaconMod.Name = "PresetBeaconMod"
        '
        'PresetBeaconTxDuration
        '
        Me.PresetBeaconTxDuration.DataPropertyName = "PresetBeaconTxDuration"
        Me.PresetBeaconTxDuration.HeaderText = "PresetBeaconTxDuration"
        Me.PresetBeaconTxDuration.Name = "PresetBeaconTxDuration"
        '
        'PresetBeaconOffDuration
        '
        Me.PresetBeaconOffDuration.DataPropertyName = "PresetBeaconOffDuration"
        Me.PresetBeaconOffDuration.HeaderText = "PresetBeaconOffDuration"
        Me.PresetBeaconOffDuration.Name = "PresetBeaconOffDuration"
        '
        'PresetBeaconTxPower
        '
        Me.PresetBeaconTxPower.DataPropertyName = "PresetBeaconTxPower"
        Me.PresetBeaconTxPower.HeaderText = "PresetBeaconTxPower"
        Me.PresetBeaconTxPower.Name = "PresetBeaconTxPower"
        '
        'PresetSpare
        '
        Me.PresetSpare.DataPropertyName = "PresetSpare"
        Me.PresetSpare.HeaderText = "PresetSpare"
        Me.PresetSpare.Name = "PresetSpare"
        '
        'PresetInScanList
        '
        Me.PresetInScanList.DataPropertyName = "PresetInScanList"
        Me.PresetInScanList.HeaderText = "PresetInScanList"
        Me.PresetInScanList.Name = "PresetInScanList"
        '
        'DataSetForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 458)
        Me.Controls.Add(Me.PRCtrainerDataGridView)
        Me.Controls.Add(Me.PRCtrainerBindingNavigator)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "DataSetForm"
        Me.Text = "DataSetForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.PRCtrainerBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PRCtrainerBindingNavigator.ResumeLayout(False)
        Me.PRCtrainerBindingNavigator.PerformLayout()
        CType(Me.PRCtrainerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StoredPresetsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PRCtrainerDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StoredPresetsDataSet As WindowsApplication1.StoredPresetsDataSet
    Friend WithEvents PRCtrainerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PRCtrainerTableAdapter As WindowsApplication1.StoredPresetsDataSetTableAdapters.PRCtrainerTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.StoredPresetsDataSetTableAdapters.TableAdapterManager
    Friend WithEvents PRCtrainerBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents PRCtrainerBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PRCtrainerDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetCryptoMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetCryptoKey As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetSatcomChannel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetDataMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetFascinatorMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetAESMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetKG84Mode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetANDVTframes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetRXfade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetANDVTautoswitch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetKeySource As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetCodebook As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetDeviation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetOptMod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetTXPower As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetTXpowerDown As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetManualSquelchSetting As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetCTCSS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetRxSquelch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetCTCSSuserEntry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetCTCSSrxUserEntry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetCTCSSrx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetChannelBusyPriority As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetCDCSStxCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetCDCSSrxCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetVinsonCompatibility As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetBeaconFreq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetBeaconMod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetBeaconTxDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetBeaconOffDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetBeaconTxPower As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetSpare As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PresetInScanList As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
