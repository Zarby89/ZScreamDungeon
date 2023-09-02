
namespace ZeldaFullEditor.Gui.MainTabs
{
    partial class SpriteEditor
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.spriteListbox = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.imperswordhammer = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.harmlessCheckbox = new System.Windows.Forms.CheckBox();
            this.invulnerableCheckbox = new System.Windows.Forms.CheckBox();
            this.childcoordinateCheckbox = new System.Windows.Forms.CheckBox();
            this.drawshadowCheckbox = new System.Windows.Forms.CheckBox();
            this.nodeathanimationCheckbox = new System.Windows.Forms.CheckBox();
            this.dieslikeabossCheckbox = new System.Windows.Forms.CheckBox();
            this.isshieldblockableCheckbox = new System.Windows.Forms.CheckBox();
            this.statisCheckbox = new System.Windows.Forms.CheckBox();
            this.persistCheckbox = new System.Windows.Forms.CheckBox();
            this.fallinholesCheckbox = new System.Windows.Forms.CheckBox();
            this.alternatedamagesoundCheckbox = new System.Windows.Forms.CheckBox();
            this.ignorecollisionCheckbox = new System.Windows.Forms.CheckBox();
            this.tileinteractionCheckbox = new System.Windows.Forms.CheckBox();
            this.imperswordhammerCheckbox = new System.Windows.Forms.CheckBox();
            this.deflectprojectileCheckbox = new System.Windows.Forms.CheckBox();
            this.impervarrowsCheckbox = new System.Windows.Forms.CheckBox();
            this.collidelessCheckbox = new System.Windows.Forms.CheckBox();
            this.watersprCheckbox = new System.Windows.Forms.CheckBox();
            this.isstatueCheckbox = new System.Windows.Forms.CheckBox();
            this.highvelocityCheckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prizepackHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.damagetypeHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.healthHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.inthitHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.hitboxHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.paletteHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.oamslotHexbox = new ZeldaFullEditor.Gui.ExtraForms.Hexbox();
            this.sprsaveButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spriteListbox
            // 
            this.spriteListbox.Dock = System.Windows.Forms.DockStyle.Left;
            this.spriteListbox.FormattingEnabled = true;
            this.spriteListbox.Location = new System.Drawing.Point(0, 0);
            this.spriteListbox.Name = "spriteListbox";
            this.spriteListbox.Size = new System.Drawing.Size(192, 557);
            this.spriteListbox.TabIndex = 0;
            this.spriteListbox.SelectedIndexChanged += new System.EventHandler(this.spriteListbox_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(399, 390);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(210, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "01E800 <- Address of compressed damage";
            this.label17.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(289, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 17);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "Ignore Collision Settings";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // imperswordhammer
            // 
            this.imperswordhammer.AutoSize = true;
            this.imperswordhammer.Location = new System.Drawing.Point(289, 88);
            this.imperswordhammer.Name = "imperswordhammer";
            this.imperswordhammer.Size = new System.Drawing.Size(170, 17);
            this.imperswordhammer.TabIndex = 21;
            this.imperswordhammer.Text = "Imprevious To Sword/Hammer";
            this.imperswordhammer.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(289, 136);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(128, 17);
            this.checkBox5.TabIndex = 23;
            this.checkBox5.Text = "Impervious To Arrows";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(471, 88);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(100, 17);
            this.checkBox7.TabIndex = 25;
            this.checkBox7.Text = "Walk On Water";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(471, 133);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(118, 17);
            this.checkBox9.TabIndex = 27;
            this.checkBox9.Text = "High Velocity Sprite";
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OAM Slots";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Palette :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Hitbox";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Int. Hitbox";
            // 
            // harmlessCheckbox
            // 
            this.harmlessCheckbox.AutoSize = true;
            this.harmlessCheckbox.Location = new System.Drawing.Point(471, 19);
            this.harmlessCheckbox.Name = "harmlessCheckbox";
            this.harmlessCheckbox.Size = new System.Drawing.Size(90, 17);
            this.harmlessCheckbox.TabIndex = 8;
            this.harmlessCheckbox.Text = "Harmless       ";
            this.harmlessCheckbox.UseVisualStyleBackColor = true;
            this.harmlessCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // invulnerableCheckbox
            // 
            this.invulnerableCheckbox.AutoSize = true;
            this.invulnerableCheckbox.Location = new System.Drawing.Point(471, 42);
            this.invulnerableCheckbox.Name = "invulnerableCheckbox";
            this.invulnerableCheckbox.Size = new System.Drawing.Size(90, 17);
            this.invulnerableCheckbox.TabIndex = 9;
            this.invulnerableCheckbox.Text = "Invulnerable  ";
            this.invulnerableCheckbox.UseVisualStyleBackColor = true;
            this.invulnerableCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // childcoordinateCheckbox
            // 
            this.childcoordinateCheckbox.AutoSize = true;
            this.childcoordinateCheckbox.Location = new System.Drawing.Point(471, 65);
            this.childcoordinateCheckbox.Name = "childcoordinateCheckbox";
            this.childcoordinateCheckbox.Size = new System.Drawing.Size(90, 17);
            this.childcoordinateCheckbox.TabIndex = 10;
            this.childcoordinateCheckbox.Text = "Adj. Coord.    ";
            this.childcoordinateCheckbox.UseVisualStyleBackColor = true;
            this.childcoordinateCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // drawshadowCheckbox
            // 
            this.drawshadowCheckbox.AutoSize = true;
            this.drawshadowCheckbox.Location = new System.Drawing.Point(148, 19);
            this.drawshadowCheckbox.Name = "drawshadowCheckbox";
            this.drawshadowCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.drawshadowCheckbox.Size = new System.Drawing.Size(93, 17);
            this.drawshadowCheckbox.TabIndex = 11;
            this.drawshadowCheckbox.Text = "Draw Shadow";
            this.drawshadowCheckbox.UseVisualStyleBackColor = true;
            this.drawshadowCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // nodeathanimationCheckbox
            // 
            this.nodeathanimationCheckbox.AutoSize = true;
            this.nodeathanimationCheckbox.Location = new System.Drawing.Point(148, 42);
            this.nodeathanimationCheckbox.Name = "nodeathanimationCheckbox";
            this.nodeathanimationCheckbox.Size = new System.Drawing.Size(121, 17);
            this.nodeathanimationCheckbox.TabIndex = 12;
            this.nodeathanimationCheckbox.Text = "No Death Animation";
            this.nodeathanimationCheckbox.UseVisualStyleBackColor = true;
            this.nodeathanimationCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // dieslikeabossCheckbox
            // 
            this.dieslikeabossCheckbox.AutoSize = true;
            this.dieslikeabossCheckbox.Location = new System.Drawing.Point(148, 65);
            this.dieslikeabossCheckbox.Name = "dieslikeabossCheckbox";
            this.dieslikeabossCheckbox.Size = new System.Drawing.Size(106, 17);
            this.dieslikeabossCheckbox.TabIndex = 13;
            this.dieslikeabossCheckbox.Text = "Dies Like A Boss";
            this.dieslikeabossCheckbox.UseVisualStyleBackColor = true;
            this.dieslikeabossCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // isshieldblockableCheckbox
            // 
            this.isshieldblockableCheckbox.AutoSize = true;
            this.isshieldblockableCheckbox.Location = new System.Drawing.Point(148, 88);
            this.isshieldblockableCheckbox.Name = "isshieldblockableCheckbox";
            this.isshieldblockableCheckbox.Size = new System.Drawing.Size(116, 17);
            this.isshieldblockableCheckbox.TabIndex = 14;
            this.isshieldblockableCheckbox.Text = "Is Shield Blockable";
            this.isshieldblockableCheckbox.UseVisualStyleBackColor = true;
            this.isshieldblockableCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // statisCheckbox
            // 
            this.statisCheckbox.AutoSize = true;
            this.statisCheckbox.Location = new System.Drawing.Point(148, 113);
            this.statisCheckbox.Name = "statisCheckbox";
            this.statisCheckbox.Size = new System.Drawing.Size(69, 17);
            this.statisCheckbox.TabIndex = 15;
            this.statisCheckbox.Text = "Not Alive";
            this.statisCheckbox.UseVisualStyleBackColor = true;
            this.statisCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // persistCheckbox
            // 
            this.persistCheckbox.AutoSize = true;
            this.persistCheckbox.Location = new System.Drawing.Point(148, 136);
            this.persistCheckbox.Name = "persistCheckbox";
            this.persistCheckbox.Size = new System.Drawing.Size(57, 17);
            this.persistCheckbox.TabIndex = 16;
            this.persistCheckbox.Text = "Persist";
            this.persistCheckbox.UseVisualStyleBackColor = true;
            this.persistCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // fallinholesCheckbox
            // 
            this.fallinholesCheckbox.AutoSize = true;
            this.fallinholesCheckbox.Location = new System.Drawing.Point(148, 159);
            this.fallinholesCheckbox.Name = "fallinholesCheckbox";
            this.fallinholesCheckbox.Size = new System.Drawing.Size(89, 17);
            this.fallinholesCheckbox.TabIndex = 17;
            this.fallinholesCheckbox.Text = "Falls In Holes";
            this.fallinholesCheckbox.UseVisualStyleBackColor = true;
            this.fallinholesCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // alternatedamagesoundCheckbox
            // 
            this.alternatedamagesoundCheckbox.AutoSize = true;
            this.alternatedamagesoundCheckbox.Location = new System.Drawing.Point(289, 19);
            this.alternatedamagesoundCheckbox.Name = "alternatedamagesoundCheckbox";
            this.alternatedamagesoundCheckbox.Size = new System.Drawing.Size(145, 17);
            this.alternatedamagesoundCheckbox.TabIndex = 18;
            this.alternatedamagesoundCheckbox.Text = "Alternate Damage Sound";
            this.alternatedamagesoundCheckbox.UseVisualStyleBackColor = true;
            this.alternatedamagesoundCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // ignorecollisionCheckbox
            // 
            this.ignorecollisionCheckbox.AutoSize = true;
            this.ignorecollisionCheckbox.Location = new System.Drawing.Point(289, 42);
            this.ignorecollisionCheckbox.Name = "ignorecollisionCheckbox";
            this.ignorecollisionCheckbox.Size = new System.Drawing.Size(138, 17);
            this.ignorecollisionCheckbox.TabIndex = 19;
            this.ignorecollisionCheckbox.Text = "Ignore Collision Settings";
            this.ignorecollisionCheckbox.UseVisualStyleBackColor = true;
            this.ignorecollisionCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // tileinteractionCheckbox
            // 
            this.tileinteractionCheckbox.AutoSize = true;
            this.tileinteractionCheckbox.Location = new System.Drawing.Point(289, 65);
            this.tileinteractionCheckbox.Name = "tileinteractionCheckbox";
            this.tileinteractionCheckbox.Size = new System.Drawing.Size(139, 17);
            this.tileinteractionCheckbox.TabIndex = 20;
            this.tileinteractionCheckbox.Text = "Disable Tile Interactions";
            this.tileinteractionCheckbox.UseVisualStyleBackColor = true;
            this.tileinteractionCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // imperswordhammerCheckbox
            // 
            this.imperswordhammerCheckbox.AutoSize = true;
            this.imperswordhammerCheckbox.Location = new System.Drawing.Point(289, 88);
            this.imperswordhammerCheckbox.Name = "imperswordhammerCheckbox";
            this.imperswordhammerCheckbox.Size = new System.Drawing.Size(170, 17);
            this.imperswordhammerCheckbox.TabIndex = 21;
            this.imperswordhammerCheckbox.Text = "Imprevious To Sword/Hammer";
            this.imperswordhammerCheckbox.UseVisualStyleBackColor = true;
            this.imperswordhammerCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // deflectprojectileCheckbox
            // 
            this.deflectprojectileCheckbox.AutoSize = true;
            this.deflectprojectileCheckbox.Location = new System.Drawing.Point(289, 113);
            this.deflectprojectileCheckbox.Name = "deflectprojectileCheckbox";
            this.deflectprojectileCheckbox.Size = new System.Drawing.Size(116, 17);
            this.deflectprojectileCheckbox.TabIndex = 22;
            this.deflectprojectileCheckbox.Text = "Deflects Projectiles";
            this.deflectprojectileCheckbox.UseVisualStyleBackColor = true;
            this.deflectprojectileCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // impervarrowsCheckbox
            // 
            this.impervarrowsCheckbox.AutoSize = true;
            this.impervarrowsCheckbox.Location = new System.Drawing.Point(289, 136);
            this.impervarrowsCheckbox.Name = "impervarrowsCheckbox";
            this.impervarrowsCheckbox.Size = new System.Drawing.Size(128, 17);
            this.impervarrowsCheckbox.TabIndex = 23;
            this.impervarrowsCheckbox.Text = "Impervious To Arrows";
            this.impervarrowsCheckbox.UseVisualStyleBackColor = true;
            this.impervarrowsCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // collidelessCheckbox
            // 
            this.collidelessCheckbox.AutoSize = true;
            this.collidelessCheckbox.Location = new System.Drawing.Point(289, 159);
            this.collidelessCheckbox.Name = "collidelessCheckbox";
            this.collidelessCheckbox.Size = new System.Drawing.Size(132, 17);
            this.collidelessCheckbox.TabIndex = 24;
            this.collidelessCheckbox.Text = "Collide With Less Tiles";
            this.collidelessCheckbox.UseVisualStyleBackColor = true;
            this.collidelessCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // watersprCheckbox
            // 
            this.watersprCheckbox.AutoSize = true;
            this.watersprCheckbox.Location = new System.Drawing.Point(471, 88);
            this.watersprCheckbox.Name = "watersprCheckbox";
            this.watersprCheckbox.Size = new System.Drawing.Size(100, 17);
            this.watersprCheckbox.TabIndex = 25;
            this.watersprCheckbox.Text = "Walk On Water";
            this.watersprCheckbox.UseVisualStyleBackColor = true;
            this.watersprCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // isstatueCheckbox
            // 
            this.isstatueCheckbox.AutoSize = true;
            this.isstatueCheckbox.Location = new System.Drawing.Point(471, 110);
            this.isstatueCheckbox.Name = "isstatueCheckbox";
            this.isstatueCheckbox.Size = new System.Drawing.Size(78, 17);
            this.isstatueCheckbox.TabIndex = 26;
            this.isstatueCheckbox.Text = "Is A Statue";
            this.isstatueCheckbox.UseVisualStyleBackColor = true;
            this.isstatueCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // highvelocityCheckbox
            // 
            this.highvelocityCheckbox.AutoSize = true;
            this.highvelocityCheckbox.Location = new System.Drawing.Point(471, 133);
            this.highvelocityCheckbox.Name = "highvelocityCheckbox";
            this.highvelocityCheckbox.Size = new System.Drawing.Size(118, 17);
            this.highvelocityCheckbox.TabIndex = 27;
            this.highvelocityCheckbox.Text = "High Velocity Sprite";
            this.highvelocityCheckbox.UseVisualStyleBackColor = true;
            this.highvelocityCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Health";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Damage Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Prize Pack";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.prizepackHexbox);
            this.groupBox1.Controls.Add(this.damagetypeHexbox);
            this.groupBox1.Controls.Add(this.healthHexbox);
            this.groupBox1.Controls.Add(this.inthitHexbox);
            this.groupBox1.Controls.Add(this.hitboxHexbox);
            this.groupBox1.Controls.Add(this.paletteHexbox);
            this.groupBox1.Controls.Add(this.oamslotHexbox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.highvelocityCheckbox);
            this.groupBox1.Controls.Add(this.isstatueCheckbox);
            this.groupBox1.Controls.Add(this.watersprCheckbox);
            this.groupBox1.Controls.Add(this.collidelessCheckbox);
            this.groupBox1.Controls.Add(this.impervarrowsCheckbox);
            this.groupBox1.Controls.Add(this.deflectprojectileCheckbox);
            this.groupBox1.Controls.Add(this.imperswordhammerCheckbox);
            this.groupBox1.Controls.Add(this.tileinteractionCheckbox);
            this.groupBox1.Controls.Add(this.ignorecollisionCheckbox);
            this.groupBox1.Controls.Add(this.alternatedamagesoundCheckbox);
            this.groupBox1.Controls.Add(this.fallinholesCheckbox);
            this.groupBox1.Controls.Add(this.persistCheckbox);
            this.groupBox1.Controls.Add(this.statisCheckbox);
            this.groupBox1.Controls.Add(this.isshieldblockableCheckbox);
            this.groupBox1.Controls.Add(this.dieslikeabossCheckbox);
            this.groupBox1.Controls.Add(this.nodeathanimationCheckbox);
            this.groupBox1.Controls.Add(this.drawshadowCheckbox);
            this.groupBox1.Controls.Add(this.childcoordinateCheckbox);
            this.groupBox1.Controls.Add(this.invulnerableCheckbox);
            this.groupBox1.Controls.Add(this.harmlessCheckbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(192, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 194);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Sprite Properties";
            // 
            // prizepackHexbox
            // 
            this.prizepackHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.prizepackHexbox.Decimal = false;
            this.prizepackHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.One;
            this.prizepackHexbox.HexValue = 0;
            this.prizepackHexbox.Location = new System.Drawing.Point(86, 158);
            this.prizepackHexbox.MaxLength = 1;
            this.prizepackHexbox.MaxValue = 8;
            this.prizepackHexbox.MinValue = 0;
            this.prizepackHexbox.Name = "prizepackHexbox";
            this.prizepackHexbox.Size = new System.Drawing.Size(53, 20);
            this.prizepackHexbox.TabIndex = 39;
            this.prizepackHexbox.Text = "0";
            this.prizepackHexbox.TextChanged += new System.EventHandler(this.properties_TextChanged);
            // 
            // damagetypeHexbox
            // 
            this.damagetypeHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.damagetypeHexbox.Decimal = false;
            this.damagetypeHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.One;
            this.damagetypeHexbox.HexValue = 0;
            this.damagetypeHexbox.Location = new System.Drawing.Point(86, 134);
            this.damagetypeHexbox.MaxLength = 1;
            this.damagetypeHexbox.MaxValue = 0;
            this.damagetypeHexbox.MinValue = 0;
            this.damagetypeHexbox.Name = "damagetypeHexbox";
            this.damagetypeHexbox.Size = new System.Drawing.Size(53, 20);
            this.damagetypeHexbox.TabIndex = 38;
            this.damagetypeHexbox.Text = "0";
            this.damagetypeHexbox.TextChanged += new System.EventHandler(this.properties_TextChanged);
            // 
            // healthHexbox
            // 
            this.healthHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.healthHexbox.Decimal = false;
            this.healthHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.healthHexbox.HexValue = 0;
            this.healthHexbox.Location = new System.Drawing.Point(86, 111);
            this.healthHexbox.MaxLength = 2;
            this.healthHexbox.MaxValue = 255;
            this.healthHexbox.MinValue = 0;
            this.healthHexbox.Name = "healthHexbox";
            this.healthHexbox.Size = new System.Drawing.Size(53, 20);
            this.healthHexbox.TabIndex = 37;
            this.healthHexbox.Text = "00";
            this.healthHexbox.TextChanged += new System.EventHandler(this.properties_TextChanged);
            // 
            // inthitHexbox
            // 
            this.inthitHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.inthitHexbox.Decimal = false;
            this.inthitHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.One;
            this.inthitHexbox.HexValue = 0;
            this.inthitHexbox.Location = new System.Drawing.Point(86, 87);
            this.inthitHexbox.MaxLength = 1;
            this.inthitHexbox.MaxValue = 0;
            this.inthitHexbox.MinValue = 0;
            this.inthitHexbox.Name = "inthitHexbox";
            this.inthitHexbox.Size = new System.Drawing.Size(53, 20);
            this.inthitHexbox.TabIndex = 36;
            this.inthitHexbox.Text = "0";
            this.inthitHexbox.TextChanged += new System.EventHandler(this.properties_TextChanged);
            // 
            // hitboxHexbox
            // 
            this.hitboxHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.hitboxHexbox.Decimal = false;
            this.hitboxHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.One;
            this.hitboxHexbox.HexValue = 0;
            this.hitboxHexbox.Location = new System.Drawing.Point(86, 63);
            this.hitboxHexbox.MaxLength = 1;
            this.hitboxHexbox.MaxValue = 0;
            this.hitboxHexbox.MinValue = 0;
            this.hitboxHexbox.Name = "hitboxHexbox";
            this.hitboxHexbox.Size = new System.Drawing.Size(53, 20);
            this.hitboxHexbox.TabIndex = 35;
            this.hitboxHexbox.Text = "0";
            this.hitboxHexbox.TextChanged += new System.EventHandler(this.properties_TextChanged);
            // 
            // paletteHexbox
            // 
            this.paletteHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.paletteHexbox.Decimal = false;
            this.paletteHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.One;
            this.paletteHexbox.HexValue = 0;
            this.paletteHexbox.Location = new System.Drawing.Point(86, 39);
            this.paletteHexbox.MaxLength = 1;
            this.paletteHexbox.MaxValue = 0;
            this.paletteHexbox.MinValue = 0;
            this.paletteHexbox.Name = "paletteHexbox";
            this.paletteHexbox.Size = new System.Drawing.Size(53, 20);
            this.paletteHexbox.TabIndex = 34;
            this.paletteHexbox.Text = "0";
            this.paletteHexbox.TextChanged += new System.EventHandler(this.properties_TextChanged);
            // 
            // oamslotHexbox
            // 
            this.oamslotHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.oamslotHexbox.Decimal = false;
            this.oamslotHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.Two;
            this.oamslotHexbox.HexValue = 0;
            this.oamslotHexbox.Location = new System.Drawing.Point(86, 15);
            this.oamslotHexbox.MaxLength = 2;
            this.oamslotHexbox.MaxValue = 64;
            this.oamslotHexbox.MinValue = 0;
            this.oamslotHexbox.Name = "oamslotHexbox";
            this.oamslotHexbox.Size = new System.Drawing.Size(53, 20);
            this.oamslotHexbox.TabIndex = 4;
            this.oamslotHexbox.Text = "00";
            this.oamslotHexbox.TextChanged += new System.EventHandler(this.properties_TextChanged);
            // 
            // sprsaveButton
            // 
            this.sprsaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sprsaveButton.Location = new System.Drawing.Point(740, 531);
            this.sprsaveButton.Name = "sprsaveButton";
            this.sprsaveButton.Size = new System.Drawing.Size(75, 23);
            this.sprsaveButton.TabIndex = 4;
            this.sprsaveButton.Text = "Save";
            this.sprsaveButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(198, 544);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(407, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "This feature is not tested you must use the Save button to save changes to the RO" +
    "M";
            // 
            // SpriteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sprsaveButton);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.spriteListbox);
            this.Name = "SpriteEditor";
            this.Size = new System.Drawing.Size(818, 557);
            this.Load += new System.EventHandler(this.SpriteEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox spriteListbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox imperswordhammer;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox harmlessCheckbox;
        private System.Windows.Forms.CheckBox invulnerableCheckbox;
        private System.Windows.Forms.CheckBox childcoordinateCheckbox;
        private System.Windows.Forms.CheckBox drawshadowCheckbox;
        private System.Windows.Forms.CheckBox nodeathanimationCheckbox;
        private System.Windows.Forms.CheckBox dieslikeabossCheckbox;
        private System.Windows.Forms.CheckBox isshieldblockableCheckbox;
        private System.Windows.Forms.CheckBox statisCheckbox;
        private System.Windows.Forms.CheckBox persistCheckbox;
        private System.Windows.Forms.CheckBox fallinholesCheckbox;
        private System.Windows.Forms.CheckBox alternatedamagesoundCheckbox;
        private System.Windows.Forms.CheckBox ignorecollisionCheckbox;
        private System.Windows.Forms.CheckBox tileinteractionCheckbox;
        private System.Windows.Forms.CheckBox imperswordhammerCheckbox;
        private System.Windows.Forms.CheckBox deflectprojectileCheckbox;
        private System.Windows.Forms.CheckBox impervarrowsCheckbox;
        private System.Windows.Forms.CheckBox collidelessCheckbox;
        private System.Windows.Forms.CheckBox watersprCheckbox;
        private System.Windows.Forms.CheckBox isstatueCheckbox;
        private System.Windows.Forms.CheckBox highvelocityCheckbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private ExtraForms.Hexbox oamslotHexbox;
        private ExtraForms.Hexbox paletteHexbox;
        private ExtraForms.Hexbox hitboxHexbox;
        private ExtraForms.Hexbox inthitHexbox;
        private ExtraForms.Hexbox healthHexbox;
        private ExtraForms.Hexbox damagetypeHexbox;
        private ExtraForms.Hexbox prizepackHexbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button sprsaveButton;
        private System.Windows.Forms.Label label8;
    }
}
