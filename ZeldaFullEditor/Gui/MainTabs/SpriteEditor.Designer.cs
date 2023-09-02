
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nopermadeathindungeonsCheckbox = new System.Windows.Forms.CheckBox();
            this.immunearrowrumbleableCheckbox = new System.Windows.Forms.CheckBox();
            this.immuneswordhammerCheckbox = new System.Windows.Forms.CheckBox();
            this.projectilelikecollisionCheckbox = new System.Windows.Forms.CheckBox();
            this.dieoffscreenCheckbox = new System.Windows.Forms.CheckBox();
            this.activeoffscreenCheckbox = new System.Windows.Forms.CheckBox();
            this.bossdamagesoundCheckbox = new System.Windows.Forms.CheckBox();
            this.blockedbyshieldCheckbox = new System.Windows.Forms.CheckBox();
            this.checkforwaterCheckbox = new System.Windows.Forms.CheckBox();
            this.invertpitbehaviorCheckbox = new System.Windows.Forms.CheckBox();
            this.dielikeabossCheckbox = new System.Windows.Forms.CheckBox();
            this.overrideslashimmunityCheckbox = new System.Windows.Forms.CheckBox();
            this.deflectarrowsCheckbox = new System.Windows.Forms.CheckBox();
            this.persistoffscreenowCheckbox = new System.Windows.Forms.CheckBox();
            this.ignoredbykillroomsCheckbox = new System.Windows.Forms.CheckBox();
            this.singlelayercollisionCheckbox = new System.Windows.Forms.CheckBox();
            this.graphicspageCheckbox = new System.Windows.Forms.CheckBox();
            this.drawshadowCheckbox = new System.Windows.Forms.CheckBox();
            this.smallshadowCheckbox = new System.Windows.Forms.CheckBox();
            this.invulnerableCheckbox = new System.Windows.Forms.CheckBox();
            this.customdeathanimationCheckbox = new System.Windows.Forms.CheckBox();
            this.allowedbossfightCheckbox = new System.Windows.Forms.CheckBox();
            this.immunepowderCheckbox = new System.Windows.Forms.CheckBox();
            this.beetargetCheckbox = new System.Windows.Forms.CheckBox();
            this.recoilwithoutcollisionCheckbox = new System.Windows.Forms.CheckBox();
            this.harmlessCheckbox = new System.Windows.Forms.CheckBox();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OAM allocation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Palette";
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
            this.label4.Text = "Tile hitbox";
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
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Bump damage class";
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
            this.groupBox1.Controls.Add(this.nopermadeathindungeonsCheckbox);
            this.groupBox1.Controls.Add(this.immunearrowrumbleableCheckbox);
            this.groupBox1.Controls.Add(this.immuneswordhammerCheckbox);
            this.groupBox1.Controls.Add(this.projectilelikecollisionCheckbox);
            this.groupBox1.Controls.Add(this.dieoffscreenCheckbox);
            this.groupBox1.Controls.Add(this.activeoffscreenCheckbox);
            this.groupBox1.Controls.Add(this.bossdamagesoundCheckbox);
            this.groupBox1.Controls.Add(this.blockedbyshieldCheckbox);
            this.groupBox1.Controls.Add(this.checkforwaterCheckbox);
            this.groupBox1.Controls.Add(this.invertpitbehaviorCheckbox);
            this.groupBox1.Controls.Add(this.dielikeabossCheckbox);
            this.groupBox1.Controls.Add(this.overrideslashimmunityCheckbox);
            this.groupBox1.Controls.Add(this.deflectarrowsCheckbox);
            this.groupBox1.Controls.Add(this.persistoffscreenowCheckbox);
            this.groupBox1.Controls.Add(this.ignoredbykillroomsCheckbox);
            this.groupBox1.Controls.Add(this.singlelayercollisionCheckbox);
            this.groupBox1.Controls.Add(this.graphicspageCheckbox);
            this.groupBox1.Controls.Add(this.drawshadowCheckbox);
            this.groupBox1.Controls.Add(this.smallshadowCheckbox);
            this.groupBox1.Controls.Add(this.invulnerableCheckbox);
            this.groupBox1.Controls.Add(this.customdeathanimationCheckbox);
            this.groupBox1.Controls.Add(this.allowedbossfightCheckbox);
            this.groupBox1.Controls.Add(this.immunepowderCheckbox);
            this.groupBox1.Controls.Add(this.beetargetCheckbox);
            this.groupBox1.Controls.Add(this.recoilwithoutcollisionCheckbox);
            this.groupBox1.Controls.Add(this.harmlessCheckbox);
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
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(192, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 186);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Sprite Properties";
            // 
            // nopermadeathindungeonsCheckbox
            // 
            this.nopermadeathindungeonsCheckbox.AutoSize = true;
            this.nopermadeathindungeonsCheckbox.Location = new System.Drawing.Point(620, 114);
            this.nopermadeathindungeonsCheckbox.Name = "nopermadeathindungeonsCheckbox";
            this.nopermadeathindungeonsCheckbox.Size = new System.Drawing.Size(160, 17);
            this.nopermadeathindungeonsCheckbox.TabIndex = 65;
            this.nopermadeathindungeonsCheckbox.Text = "No permadeath in dungeons";
            this.nopermadeathindungeonsCheckbox.UseVisualStyleBackColor = true;
            this.nopermadeathindungeonsCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // immunearrowrumbleableCheckbox
            // 
            this.immunearrowrumbleableCheckbox.AutoSize = true;
            this.immunearrowrumbleableCheckbox.Location = new System.Drawing.Point(620, 89);
            this.immunearrowrumbleableCheckbox.Name = "immunearrowrumbleableCheckbox";
            this.immunearrowrumbleableCheckbox.Size = new System.Drawing.Size(165, 17);
            this.immunearrowrumbleableCheckbox.TabIndex = 64;
            this.immunearrowrumbleableCheckbox.Text = "Immune to arrows/rumbleable";
            this.immunearrowrumbleableCheckbox.UseVisualStyleBackColor = true;
            this.immunearrowrumbleableCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // immuneswordhammerCheckbox
            // 
            this.immuneswordhammerCheckbox.AutoSize = true;
            this.immuneswordhammerCheckbox.Location = new System.Drawing.Point(620, 64);
            this.immuneswordhammerCheckbox.Name = "immuneswordhammerCheckbox";
            this.immuneswordhammerCheckbox.Size = new System.Drawing.Size(148, 17);
            this.immuneswordhammerCheckbox.TabIndex = 63;
            this.immuneswordhammerCheckbox.Text = "Immune to sword/hammer";
            this.immuneswordhammerCheckbox.UseVisualStyleBackColor = true;
            this.immuneswordhammerCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // projectilelikecollisionCheckbox
            // 
            this.projectilelikecollisionCheckbox.AutoSize = true;
            this.projectilelikecollisionCheckbox.Location = new System.Drawing.Point(620, 39);
            this.projectilelikecollisionCheckbox.Name = "projectilelikecollisionCheckbox";
            this.projectilelikecollisionCheckbox.Size = new System.Drawing.Size(128, 17);
            this.projectilelikecollisionCheckbox.TabIndex = 62;
            this.projectilelikecollisionCheckbox.Text = "Projectile-like collision";
            this.projectilelikecollisionCheckbox.UseVisualStyleBackColor = true;
            this.projectilelikecollisionCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // dieoffscreenCheckbox
            // 
            this.dieoffscreenCheckbox.AutoSize = true;
            this.dieoffscreenCheckbox.Location = new System.Drawing.Point(620, 14);
            this.dieoffscreenCheckbox.Name = "dieoffscreenCheckbox";
            this.dieoffscreenCheckbox.Size = new System.Drawing.Size(92, 17);
            this.dieoffscreenCheckbox.TabIndex = 61;
            this.dieoffscreenCheckbox.Text = "Die off screen";
            this.dieoffscreenCheckbox.UseVisualStyleBackColor = true;
            this.dieoffscreenCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // activeoffscreenCheckbox
            // 
            this.activeoffscreenCheckbox.AutoSize = true;
            this.activeoffscreenCheckbox.Location = new System.Drawing.Point(469, 165);
            this.activeoffscreenCheckbox.Name = "activeoffscreenCheckbox";
            this.activeoffscreenCheckbox.Size = new System.Drawing.Size(106, 17);
            this.activeoffscreenCheckbox.TabIndex = 60;
            this.activeoffscreenCheckbox.Text = "Active off screen";
            this.activeoffscreenCheckbox.UseVisualStyleBackColor = true;
            this.activeoffscreenCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // bossdamagesoundCheckbox
            // 
            this.bossdamagesoundCheckbox.AutoSize = true;
            this.bossdamagesoundCheckbox.Location = new System.Drawing.Point(469, 140);
            this.bossdamagesoundCheckbox.Name = "bossdamagesoundCheckbox";
            this.bossdamagesoundCheckbox.Size = new System.Drawing.Size(122, 17);
            this.bossdamagesoundCheckbox.TabIndex = 59;
            this.bossdamagesoundCheckbox.Text = "Boss damage sound";
            this.bossdamagesoundCheckbox.UseVisualStyleBackColor = true;
            this.bossdamagesoundCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // blockedbyshieldCheckbox
            // 
            this.blockedbyshieldCheckbox.AutoSize = true;
            this.blockedbyshieldCheckbox.Location = new System.Drawing.Point(469, 115);
            this.blockedbyshieldCheckbox.Name = "blockedbyshieldCheckbox";
            this.blockedbyshieldCheckbox.Size = new System.Drawing.Size(109, 17);
            this.blockedbyshieldCheckbox.TabIndex = 58;
            this.blockedbyshieldCheckbox.Text = "Blocked by shield";
            this.blockedbyshieldCheckbox.UseVisualStyleBackColor = true;
            this.blockedbyshieldCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // checkforwaterCheckbox
            // 
            this.checkforwaterCheckbox.AutoSize = true;
            this.checkforwaterCheckbox.Location = new System.Drawing.Point(469, 90);
            this.checkforwaterCheckbox.Name = "checkforwaterCheckbox";
            this.checkforwaterCheckbox.Size = new System.Drawing.Size(101, 17);
            this.checkforwaterCheckbox.TabIndex = 57;
            this.checkforwaterCheckbox.Text = "Check for water";
            this.checkforwaterCheckbox.UseVisualStyleBackColor = true;
            this.checkforwaterCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // invertpitbehaviorCheckbox
            // 
            this.invertpitbehaviorCheckbox.AutoSize = true;
            this.invertpitbehaviorCheckbox.Location = new System.Drawing.Point(469, 64);
            this.invertpitbehaviorCheckbox.Name = "invertpitbehaviorCheckbox";
            this.invertpitbehaviorCheckbox.Size = new System.Drawing.Size(111, 17);
            this.invertpitbehaviorCheckbox.TabIndex = 56;
            this.invertpitbehaviorCheckbox.Text = "Invert pit behavior";
            this.invertpitbehaviorCheckbox.UseVisualStyleBackColor = true;
            this.invertpitbehaviorCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // dielikeabossCheckbox
            // 
            this.dielikeabossCheckbox.AutoSize = true;
            this.dielikeabossCheckbox.Location = new System.Drawing.Point(469, 39);
            this.dielikeabossCheckbox.Name = "dielikeabossCheckbox";
            this.dielikeabossCheckbox.Size = new System.Drawing.Size(95, 17);
            this.dielikeabossCheckbox.TabIndex = 55;
            this.dielikeabossCheckbox.Text = "Die like a boss";
            this.dielikeabossCheckbox.UseVisualStyleBackColor = true;
            this.dielikeabossCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // overrideslashimmunityCheckbox
            // 
            this.overrideslashimmunityCheckbox.AutoSize = true;
            this.overrideslashimmunityCheckbox.Location = new System.Drawing.Point(469, 14);
            this.overrideslashimmunityCheckbox.Name = "overrideslashimmunityCheckbox";
            this.overrideslashimmunityCheckbox.Size = new System.Drawing.Size(136, 17);
            this.overrideslashimmunityCheckbox.TabIndex = 54;
            this.overrideslashimmunityCheckbox.Text = "Override slash immunity";
            this.overrideslashimmunityCheckbox.UseVisualStyleBackColor = true;
            this.overrideslashimmunityCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // deflectarrowsCheckbox
            // 
            this.deflectarrowsCheckbox.AutoSize = true;
            this.deflectarrowsCheckbox.Location = new System.Drawing.Point(320, 165);
            this.deflectarrowsCheckbox.Name = "deflectarrowsCheckbox";
            this.deflectarrowsCheckbox.Size = new System.Drawing.Size(94, 17);
            this.deflectarrowsCheckbox.TabIndex = 53;
            this.deflectarrowsCheckbox.Text = "Deflect arrows";
            this.deflectarrowsCheckbox.UseVisualStyleBackColor = true;
            this.deflectarrowsCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // persistoffscreenowCheckbox
            // 
            this.persistoffscreenowCheckbox.AutoSize = true;
            this.persistoffscreenowCheckbox.Location = new System.Drawing.Point(320, 140);
            this.persistoffscreenowCheckbox.Name = "persistoffscreenowCheckbox";
            this.persistoffscreenowCheckbox.Size = new System.Drawing.Size(137, 17);
            this.persistoffscreenowCheckbox.TabIndex = 52;
            this.persistoffscreenowCheckbox.Text = "Persist offscreen in OW";
            this.persistoffscreenowCheckbox.UseVisualStyleBackColor = true;
            this.persistoffscreenowCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // ignoredbykillroomsCheckbox
            // 
            this.ignoredbykillroomsCheckbox.AutoSize = true;
            this.ignoredbykillroomsCheckbox.Location = new System.Drawing.Point(320, 115);
            this.ignoredbykillroomsCheckbox.Name = "ignoredbykillroomsCheckbox";
            this.ignoredbykillroomsCheckbox.Size = new System.Drawing.Size(122, 17);
            this.ignoredbykillroomsCheckbox.TabIndex = 51;
            this.ignoredbykillroomsCheckbox.Text = "Ignored by kill rooms";
            this.ignoredbykillroomsCheckbox.UseVisualStyleBackColor = true;
            this.ignoredbykillroomsCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // singlelayercollisionCheckbox
            // 
            this.singlelayercollisionCheckbox.AutoSize = true;
            this.singlelayercollisionCheckbox.Location = new System.Drawing.Point(320, 90);
            this.singlelayercollisionCheckbox.Name = "singlelayercollisionCheckbox";
            this.singlelayercollisionCheckbox.Size = new System.Drawing.Size(120, 17);
            this.singlelayercollisionCheckbox.TabIndex = 50;
            this.singlelayercollisionCheckbox.Text = "Single layer collision";
            this.singlelayercollisionCheckbox.UseVisualStyleBackColor = true;
            this.singlelayercollisionCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // graphicspageCheckbox
            // 
            this.graphicspageCheckbox.AutoSize = true;
            this.graphicspageCheckbox.Location = new System.Drawing.Point(320, 65);
            this.graphicspageCheckbox.Name = "graphicspageCheckbox";
            this.graphicspageCheckbox.Size = new System.Drawing.Size(95, 17);
            this.graphicspageCheckbox.TabIndex = 49;
            this.graphicspageCheckbox.Text = "Graphics page";
            this.graphicspageCheckbox.UseVisualStyleBackColor = true;
            this.graphicspageCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // drawshadowCheckbox
            // 
            this.drawshadowCheckbox.AutoSize = true;
            this.drawshadowCheckbox.Location = new System.Drawing.Point(320, 40);
            this.drawshadowCheckbox.Name = "drawshadowCheckbox";
            this.drawshadowCheckbox.Size = new System.Drawing.Size(97, 17);
            this.drawshadowCheckbox.TabIndex = 48;
            this.drawshadowCheckbox.Text = "Draw shadow?";
            this.drawshadowCheckbox.UseVisualStyleBackColor = true;
            this.drawshadowCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // smallshadowCheckbox
            // 
            this.smallshadowCheckbox.AutoSize = true;
            this.smallshadowCheckbox.Location = new System.Drawing.Point(320, 16);
            this.smallshadowCheckbox.Name = "smallshadowCheckbox";
            this.smallshadowCheckbox.Size = new System.Drawing.Size(97, 17);
            this.smallshadowCheckbox.TabIndex = 47;
            this.smallshadowCheckbox.Text = "Small shadow?";
            this.smallshadowCheckbox.UseVisualStyleBackColor = true;
            this.smallshadowCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // invulnerableCheckbox
            // 
            this.invulnerableCheckbox.AutoSize = true;
            this.invulnerableCheckbox.Location = new System.Drawing.Point(174, 165);
            this.invulnerableCheckbox.Name = "invulnerableCheckbox";
            this.invulnerableCheckbox.Size = new System.Drawing.Size(84, 17);
            this.invulnerableCheckbox.TabIndex = 46;
            this.invulnerableCheckbox.Text = "Invulnerable";
            this.invulnerableCheckbox.UseVisualStyleBackColor = true;
            this.invulnerableCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // customdeathanimationCheckbox
            // 
            this.customdeathanimationCheckbox.AutoSize = true;
            this.customdeathanimationCheckbox.Location = new System.Drawing.Point(174, 140);
            this.customdeathanimationCheckbox.Name = "customdeathanimationCheckbox";
            this.customdeathanimationCheckbox.Size = new System.Drawing.Size(139, 17);
            this.customdeathanimationCheckbox.TabIndex = 45;
            this.customdeathanimationCheckbox.Text = "Custom death animation";
            this.customdeathanimationCheckbox.UseVisualStyleBackColor = true;
            this.customdeathanimationCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // allowedbossfightCheckbox
            // 
            this.allowedbossfightCheckbox.AutoSize = true;
            this.allowedbossfightCheckbox.Location = new System.Drawing.Point(174, 115);
            this.allowedbossfightCheckbox.Name = "allowedbossfightCheckbox";
            this.allowedbossfightCheckbox.Size = new System.Drawing.Size(127, 17);
            this.allowedbossfightCheckbox.TabIndex = 44;
            this.allowedbossfightCheckbox.Text = "Allowed in boss fights";
            this.allowedbossfightCheckbox.UseVisualStyleBackColor = true;
            this.allowedbossfightCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // immunepowderCheckbox
            // 
            this.immunepowderCheckbox.AutoSize = true;
            this.immunepowderCheckbox.Location = new System.Drawing.Point(174, 90);
            this.immunepowderCheckbox.Name = "immunepowderCheckbox";
            this.immunepowderCheckbox.Size = new System.Drawing.Size(113, 17);
            this.immunepowderCheckbox.TabIndex = 43;
            this.immunepowderCheckbox.Text = "Immune to powder";
            this.immunepowderCheckbox.UseVisualStyleBackColor = true;
            this.immunepowderCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // beetargetCheckbox
            // 
            this.beetargetCheckbox.AutoSize = true;
            this.beetargetCheckbox.Location = new System.Drawing.Point(174, 65);
            this.beetargetCheckbox.Name = "beetargetCheckbox";
            this.beetargetCheckbox.Size = new System.Drawing.Size(75, 17);
            this.beetargetCheckbox.TabIndex = 42;
            this.beetargetCheckbox.Text = "Bee target";
            this.beetargetCheckbox.UseVisualStyleBackColor = true;
            this.beetargetCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // recoilwithoutcollisionCheckbox
            // 
            this.recoilwithoutcollisionCheckbox.AutoSize = true;
            this.recoilwithoutcollisionCheckbox.Location = new System.Drawing.Point(174, 40);
            this.recoilwithoutcollisionCheckbox.Name = "recoilwithoutcollisionCheckbox";
            this.recoilwithoutcollisionCheckbox.Size = new System.Drawing.Size(133, 17);
            this.recoilwithoutcollisionCheckbox.TabIndex = 41;
            this.recoilwithoutcollisionCheckbox.Text = "Recoil without collision";
            this.recoilwithoutcollisionCheckbox.UseVisualStyleBackColor = true;
            this.recoilwithoutcollisionCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // harmlessCheckbox
            // 
            this.harmlessCheckbox.AutoSize = true;
            this.harmlessCheckbox.Location = new System.Drawing.Point(174, 16);
            this.harmlessCheckbox.Name = "harmlessCheckbox";
            this.harmlessCheckbox.Size = new System.Drawing.Size(69, 17);
            this.harmlessCheckbox.TabIndex = 40;
            this.harmlessCheckbox.Text = "Harmless";
            this.harmlessCheckbox.UseVisualStyleBackColor = true;
            this.harmlessCheckbox.CheckedChanged += new System.EventHandler(this.properties_CheckedChanged);
            // 
            // prizepackHexbox
            // 
            this.prizepackHexbox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.prizepackHexbox.Decimal = false;
            this.prizepackHexbox.Digits = ZeldaFullEditor.Gui.ExtraForms.Hexbox.HexDigits.One;
            this.prizepackHexbox.HexValue = 0;
            this.prizepackHexbox.Location = new System.Drawing.Point(115, 159);
            this.prizepackHexbox.MaxLength = 1;
            this.prizepackHexbox.MaxValue = 7;
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
            this.damagetypeHexbox.Location = new System.Drawing.Point(115, 135);
            this.damagetypeHexbox.MaxLength = 1;
            this.damagetypeHexbox.MaxValue = 15;
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
            this.healthHexbox.Location = new System.Drawing.Point(115, 112);
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
            this.inthitHexbox.Location = new System.Drawing.Point(115, 88);
            this.inthitHexbox.MaxLength = 1;
            this.inthitHexbox.MaxValue = 15;
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
            this.hitboxHexbox.Location = new System.Drawing.Point(115, 64);
            this.hitboxHexbox.MaxLength = 1;
            this.hitboxHexbox.MaxValue = 15;
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
            this.paletteHexbox.Location = new System.Drawing.Point(115, 40);
            this.paletteHexbox.MaxLength = 1;
            this.paletteHexbox.MaxValue = 7;
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
            this.oamslotHexbox.Location = new System.Drawing.Point(115, 16);
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
            this.sprsaveButton.Location = new System.Drawing.Point(911, 531);
            this.sprsaveButton.Name = "sprsaveButton";
            this.sprsaveButton.Size = new System.Drawing.Size(75, 23);
            this.sprsaveButton.TabIndex = 4;
            this.sprsaveButton.Text = "Save";
            this.sprsaveButton.UseVisualStyleBackColor = true;
            this.sprsaveButton.Click += new System.EventHandler(this.sprsaveButton_Click);
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
            this.Size = new System.Drawing.Size(989, 557);
            this.Load += new System.EventHandler(this.SpriteEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox spriteListbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
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
        private System.Windows.Forms.CheckBox harmlessCheckbox;
        private System.Windows.Forms.CheckBox smallshadowCheckbox;
        private System.Windows.Forms.CheckBox invulnerableCheckbox;
        private System.Windows.Forms.CheckBox customdeathanimationCheckbox;
        private System.Windows.Forms.CheckBox allowedbossfightCheckbox;
        private System.Windows.Forms.CheckBox immunepowderCheckbox;
        private System.Windows.Forms.CheckBox beetargetCheckbox;
        private System.Windows.Forms.CheckBox recoilwithoutcollisionCheckbox;
        private System.Windows.Forms.CheckBox invertpitbehaviorCheckbox;
        private System.Windows.Forms.CheckBox dielikeabossCheckbox;
        private System.Windows.Forms.CheckBox overrideslashimmunityCheckbox;
        private System.Windows.Forms.CheckBox deflectarrowsCheckbox;
        private System.Windows.Forms.CheckBox persistoffscreenowCheckbox;
        private System.Windows.Forms.CheckBox ignoredbykillroomsCheckbox;
        private System.Windows.Forms.CheckBox singlelayercollisionCheckbox;
        private System.Windows.Forms.CheckBox graphicspageCheckbox;
        private System.Windows.Forms.CheckBox drawshadowCheckbox;
        private System.Windows.Forms.CheckBox immunearrowrumbleableCheckbox;
        private System.Windows.Forms.CheckBox immuneswordhammerCheckbox;
        private System.Windows.Forms.CheckBox projectilelikecollisionCheckbox;
        private System.Windows.Forms.CheckBox dieoffscreenCheckbox;
        private System.Windows.Forms.CheckBox activeoffscreenCheckbox;
        private System.Windows.Forms.CheckBox bossdamagesoundCheckbox;
        private System.Windows.Forms.CheckBox blockedbyshieldCheckbox;
        private System.Windows.Forms.CheckBox checkforwaterCheckbox;
        private System.Windows.Forms.CheckBox nopermadeathindungeonsCheckbox;
    }
}
