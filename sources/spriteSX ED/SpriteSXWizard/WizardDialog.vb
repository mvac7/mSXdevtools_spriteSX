Imports System.Windows.Forms

Public Class WizardDialog

    Private WizardStep As Integer = 0

    Private WizardControl As Windows.Forms.Control

    Public SpritePrjName As String = ""
    Public SpriteSize As Integer = 1
    Public SpriteSizeTag As String
    Public SpriteMode As Integer = 1
    Public SpriteModeTag As String

    'Public SpriteProject As SpriteProjectData


    Public Sub New()

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub


    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub setQuestion1()
        Me.WizardStep = 1

        Me.TitleLabel.Text = "Entry Project Name"
        Me.StepLabel.Text = "1/4"
        Me.InfoLabel.Text = ""

        Dim WizardQuestion As WizardSpritePrjName = New WizardSpritePrjName
        Me.SuspendLayout()

        WizardQuestion.Dock = System.Windows.Forms.DockStyle.Fill
        WizardQuestion.Location = New System.Drawing.Point(0, 0)
        WizardQuestion.Name = "SpritePanel"
        WizardQuestion.Size = New System.Drawing.Size(464, 150)
        WizardQuestion.TabIndex = 9

        Me.WizardPanel.Controls.Add(WizardQuestion)

        Me.WizardControl = WizardQuestion

        Me.ResumeLayout(False)

        AddHandler WizardQuestion.SetName, AddressOf Me.SetName

        Application.DoEvents()

        'WizardQuestion.NameTextBox.Focus()

        Me.ActiveControl = WizardQuestion.NameTextBox 'control de foco

        If Not Me.SpritePrjName = "" Then ' si es un paso atras y tenemos el valor del nombre, 
            WizardQuestion.NameTextBox.Text = Me.SpritePrjName                    ' lo muestra
        End If

        Me.BackButton.Enabled = False

    End Sub



    Private Sub setQuestion2()
        Me.WizardStep = 2

        Me.TitleLabel.Text = "Select Size"
        Me.StepLabel.Text = "2/4"
        Me.InfoLabel.Text = Me.SpritePrjName

        Dim WizardQuestion As WizardSpriteSize = New WizardSpriteSize
        Me.SuspendLayout()

        WizardQuestion.Dock = System.Windows.Forms.DockStyle.Fill
        WizardQuestion.Location = New System.Drawing.Point(0, 0)
        WizardQuestion.Name = "SpritePanel"
        WizardQuestion.Size = New System.Drawing.Size(464, 150)
        WizardQuestion.TabIndex = 9

        Me.WizardPanel.Controls.Add(WizardQuestion)

        Me.ResumeLayout(False)

        Me.WizardControl = WizardQuestion

        AddHandler WizardQuestion.SetSize, AddressOf Me.SetSize

        Me.ActiveControl = WizardQuestion.EightButton 'control de foco

        Me.BackButton.Enabled = True

    End Sub


    Private Sub setQuestion3()
        Me.WizardStep = 3

        Me.TitleLabel.Text = "Select Color Mode"
        Me.StepLabel.Text = "3/4"
        Me.InfoLabel.Text = Me.SpritePrjName + " > " + SpriteSizeTag

        Dim WizardQuestion As WizardSpriteColor = New WizardSpriteColor
        Me.SuspendLayout()

        WizardQuestion.Dock = System.Windows.Forms.DockStyle.Fill
        WizardQuestion.Location = New System.Drawing.Point(0, 0)
        WizardQuestion.Name = "SpritePanel"
        WizardQuestion.Size = New System.Drawing.Size(464, 150)
        WizardQuestion.TabIndex = 9

        Me.WizardPanel.Controls.Add(WizardQuestion)

        Me.ResumeLayout(False)

        Me.WizardControl = WizardQuestion

        AddHandler WizardQuestion.SetMode, AddressOf Me.SetMode

        Me.ActiveControl = WizardQuestion.OneColorButton 'control de foco

        Me.BackButton.Enabled = True

    End Sub


    Private Sub setQuestion4()
        Me.WizardStep = 4

        Me.TitleLabel.Text = "Confirm Data"
        Me.StepLabel.Text = "4/4"
        Me.InfoLabel.Text = " " 'Me.SpritePrjName + " > " + SpriteSizeTag

        Dim WizardQuestion As WizardConfirm = New WizardConfirm
        Me.SuspendLayout()

        WizardQuestion.Dock = System.Windows.Forms.DockStyle.Fill
        WizardQuestion.Location = New System.Drawing.Point(0, 0)
        WizardQuestion.Name = "SpritePanel"
        WizardQuestion.Size = New System.Drawing.Size(464, 150)
        WizardQuestion.TabIndex = 9

        Me.WizardPanel.Controls.Add(WizardQuestion)

        Me.ResumeLayout(False)

        Me.WizardControl = WizardQuestion

        ' muestra los datos
        WizardQuestion.ProjectName = Me.SpritePrjName
        WizardQuestion.ProjectSize = Me.SpriteSizeTag
        WizardQuestion.ProjectMode = Me.SpriteModeTag

        AddHandler WizardQuestion.SetData, AddressOf Me.SetData

        'Me.ActiveControl = WizardQuestion.OneColorButton 'control de foco

        Me.BackButton.Enabled = True

    End Sub


    Private Sub SetData(ByVal value As Boolean)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub


    Private Sub WizardDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        setQuestion1()
    End Sub

    'Private Sub BackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackButton.Click
    '    setQuestion1()
    'End Sub




    Private Sub SetName(ByVal namePrj As String) ' Handles Next1Button.Click
        Me.SpritePrjName = namePrj
        setStep(2)
    End Sub


    Private Sub SetSize(ByVal _size As Integer)
        If _size = 1 Then
            Me.SpriteSize = 1
            Me.SpriteSizeTag = "8x8"
            setStep(3)
        Else
            Me.SpriteSize = 2
            Me.SpriteSizeTag = "16x16"
            setStep(3)
        End If
    End Sub


    Private Sub SetMode(ByVal _mode As Integer)
        If _mode = 1 Then
            Me.SpriteMode = 1
            Me.SpriteModeTag = "one color"
            setStep(4)
        Else
            Me.SpriteMode = 2
            Me.SpriteModeTag = "multicolor"
            setStep(4)
        End If

        'Me.SpriteMode = _mode

    End Sub


    Private Sub setStep(ByVal _step As Integer)

        If Not Me.WizardControl Is Nothing Then
            Me.WizardControl.Dispose()
        End If

        Select Case _step
            Case 1
                setQuestion1()
            Case 2
                setQuestion2()
            Case 3
                setQuestion3()
            Case 4
                setQuestion4()

        End Select
    End Sub

    Private Sub BackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackButton.Click
        If Me.WizardStep > 1 Then
            Me.WizardStep -= 1
            setStep(Me.WizardStep)
        End If
    End Sub
End Class