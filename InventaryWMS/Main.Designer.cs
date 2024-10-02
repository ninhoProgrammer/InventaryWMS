
using System;
using System.Windows.Forms;

namespace InventaryWMS
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolArchive = new System.Windows.Forms.ToolStripDropDownButton();
            this.cambioClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolConfiguration = new System.Windows.Forms.ToolStripDropDownButton();
            this.systemConfigurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolEdit = new System.Windows.Forms.ToolStripDropDownButton();
            this.warehouseEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.destinationsEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addEmailEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateEmailEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEmailEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permissionsEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPermissionsEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePermissionsEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonInventory = new System.Windows.Forms.Button();
            this.btnStoreProducts = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonInput = new System.Windows.Forms.Button();
            this.buttonProducts = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonBinnacle = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.withoutInternetToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.withInternetToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.userToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.companyToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolArchive,
            this.toolConfiguration,
            this.toolEdit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolArchive
            // 
            this.toolArchive.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambioClienteToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.toolArchive.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolArchive.Image = global::InventaryWMS.Properties.Resources.icons8_abrir_carpeta_64;
            this.toolArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolArchive.Name = "toolArchive";
            this.toolArchive.Size = new System.Drawing.Size(77, 22);
            this.toolArchive.Text = "Archivo";
            // 
            // cambioClienteToolStripMenuItem
            // 
            this.cambioClienteToolStripMenuItem.Name = "cambioClienteToolStripMenuItem";
            this.cambioClienteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.cambioClienteToolStripMenuItem.Text = "Cambio Cliente";
            this.cambioClienteToolStripMenuItem.Click += new System.EventHandler(this.CompanyMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.UserMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // toolConfiguration
            // 
            this.toolConfiguration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemConfigurationMenuItem});
            this.toolConfiguration.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolConfiguration.Image = global::InventaryWMS.Properties.Resources.icons8_configuración_64;
            this.toolConfiguration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolConfiguration.Name = "toolConfiguration";
            this.toolConfiguration.Size = new System.Drawing.Size(112, 22);
            this.toolConfiguration.Text = "Configuración";
            // 
            // systemConfigurationMenuItem
            // 
            this.systemConfigurationMenuItem.Name = "systemConfigurationMenuItem";
            this.systemConfigurationMenuItem.Size = new System.Drawing.Size(115, 22);
            this.systemConfigurationMenuItem.Text = "Sistema";
            this.systemConfigurationMenuItem.Click += new System.EventHandler(this.SystemConfigurationMenuItem_Click);
            // 
            // toolEdit
            // 
            this.toolEdit.BackColor = System.Drawing.Color.Transparent;
            this.toolEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.warehouseEditMenuItem,
            this.clientsEditMenuItem,
            this.proToolStripMenuItem,
            this.inveToolStripMenuItem,
            this.destinationsEditMenuItem,
            this.productEditMenuItem,
            this.permisosToolStripMenuItem,
            this.commandEditMenuItem,
            this.userEditMenuItem,
            this.emailEditMenuItem,
            this.asignarToolStripMenuItem});
            this.toolEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolEdit.Image = global::InventaryWMS.Properties.Resources.icons8_editar_archivo_64;
            this.toolEdit.ImageTransparentColor = System.Drawing.SystemColors.WindowFrame;
            this.toolEdit.Name = "toolEdit";
            this.toolEdit.Size = new System.Drawing.Size(98, 22);
            this.toolEdit.Text = "Administrar";
            this.toolEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolEdit.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // warehouseEditMenuItem
            // 
            this.warehouseEditMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.warehouseEditMenuItem.Name = "warehouseEditMenuItem";
            this.warehouseEditMenuItem.Size = new System.Drawing.Size(140, 22);
            this.warehouseEditMenuItem.Text = "Almacén";
            this.warehouseEditMenuItem.Click += new System.EventHandler(this.warehouseEditMenuItem_Click);
            // 
            // clientsEditMenuItem
            // 
            this.clientsEditMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.clientsEditMenuItem.Name = "clientsEditMenuItem";
            this.clientsEditMenuItem.Size = new System.Drawing.Size(140, 22);
            this.clientsEditMenuItem.Text = "Cliente";
            this.clientsEditMenuItem.Click += new System.EventHandler(this.clientsEditMenuItem_Click);
            // 
            // proToolStripMenuItem
            // 
            this.proToolStripMenuItem.Name = "proToolStripMenuItem";
            this.proToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.proToolStripMenuItem.Text = "Proveedor";
            this.proToolStripMenuItem.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // inveToolStripMenuItem
            // 
            this.inveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventarioToolStripMenuItem1,
            this.transferenciasToolStripMenuItem1});
            this.inveToolStripMenuItem.Name = "inveToolStripMenuItem";
            this.inveToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.inveToolStripMenuItem.Text = "Inventario";
            this.inveToolStripMenuItem.Click += new System.EventHandler(this.inveToolStripMenuItem_Click);
            // 
            // inventarioToolStripMenuItem1
            // 
            this.inventarioToolStripMenuItem1.Name = "inventarioToolStripMenuItem1";
            this.inventarioToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.inventarioToolStripMenuItem1.Text = "Inventario";
            // 
            // transferenciasToolStripMenuItem1
            // 
            this.transferenciasToolStripMenuItem1.Name = "transferenciasToolStripMenuItem1";
            this.transferenciasToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.transferenciasToolStripMenuItem1.Text = "Transferencias";
            this.transferenciasToolStripMenuItem1.Click += new System.EventHandler(this.transferenciasToolStripMenuItem1_Click);
            // 
            // destinationsEditMenuItem
            // 
            this.destinationsEditMenuItem.Name = "destinationsEditMenuItem";
            this.destinationsEditMenuItem.Size = new System.Drawing.Size(140, 22);
            this.destinationsEditMenuItem.Text = "Responsable";
            this.destinationsEditMenuItem.Click += new System.EventHandler(this.destinationsEditMenuItem_Click);
            // 
            // productEditMenuItem
            // 
            this.productEditMenuItem.Name = "productEditMenuItem";
            this.productEditMenuItem.ShowShortcutKeys = false;
            this.productEditMenuItem.Size = new System.Drawing.Size(140, 22);
            this.productEditMenuItem.Text = "Productos";
            this.productEditMenuItem.Click += new System.EventHandler(this.productEditMenuItem_Click);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.permisosToolStripMenuItem.Text = "Permisos";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // commandEditMenuItem
            // 
            this.commandEditMenuItem.Name = "commandEditMenuItem";
            this.commandEditMenuItem.Size = new System.Drawing.Size(140, 22);
            this.commandEditMenuItem.Text = "Orden";
            this.commandEditMenuItem.Click += new System.EventHandler(this.commandEditMenuItem_Click);
            // 
            // userEditMenuItem
            // 
            this.userEditMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.userEditMenuItem.Name = "userEditMenuItem";
            this.userEditMenuItem.Size = new System.Drawing.Size(140, 22);
            this.userEditMenuItem.Text = "Usuario";
            this.userEditMenuItem.Click += new System.EventHandler(this.userEditMenuItem_Click);
            // 
            // emailEditMenuItem
            // 
            this.emailEditMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.emailEditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEmailEditMenuItem,
            this.updateEmailEditMenuItem,
            this.deleteEmailEditMenuItem});
            this.emailEditMenuItem.Name = "emailEditMenuItem";
            this.emailEditMenuItem.Size = new System.Drawing.Size(140, 22);
            this.emailEditMenuItem.Text = "Correos";
            // 
            // addEmailEditMenuItem
            // 
            this.addEmailEditMenuItem.Name = "addEmailEditMenuItem";
            this.addEmailEditMenuItem.Size = new System.Drawing.Size(125, 22);
            this.addEmailEditMenuItem.Text = "Agregar";
            this.addEmailEditMenuItem.Click += new System.EventHandler(this.addEmailEditMenuItem_Click);
            // 
            // updateEmailEditMenuItem
            // 
            this.updateEmailEditMenuItem.Name = "updateEmailEditMenuItem";
            this.updateEmailEditMenuItem.Size = new System.Drawing.Size(125, 22);
            this.updateEmailEditMenuItem.Text = "Modificar";
            this.updateEmailEditMenuItem.Click += new System.EventHandler(this.updateEmailEditMenuItem_Click);
            // 
            // deleteEmailEditMenuItem
            // 
            this.deleteEmailEditMenuItem.Name = "deleteEmailEditMenuItem";
            this.deleteEmailEditMenuItem.Size = new System.Drawing.Size(125, 22);
            this.deleteEmailEditMenuItem.Text = "Eliminar";
            this.deleteEmailEditMenuItem.Click += new System.EventHandler(this.deleteEmailEditMenuItem_Click);
            // 
            // asignarToolStripMenuItem
            // 
            this.asignarToolStripMenuItem.Name = "asignarToolStripMenuItem";
            this.asignarToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.asignarToolStripMenuItem.Text = "Asignar";
            this.asignarToolStripMenuItem.Click += new System.EventHandler(this.asignarToolStripMenuItem_Click);
            // 
            // permissionsEditMenuItem
            // 
            this.permissionsEditMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.permissionsEditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPermissionsEditMenuItem,
            this.deletePermissionsEditMenuItem,
            this.toolStripMenuItem1});
            this.permissionsEditMenuItem.Name = "permissionsEditMenuItem";
            this.permissionsEditMenuItem.Size = new System.Drawing.Size(180, 22);
            this.permissionsEditMenuItem.Text = "Permisos";
            // 
            // addPermissionsEditMenuItem
            // 
            this.addPermissionsEditMenuItem.Name = "addPermissionsEditMenuItem";
            this.addPermissionsEditMenuItem.Size = new System.Drawing.Size(125, 22);
            this.addPermissionsEditMenuItem.Text = "Agregar";
            this.addPermissionsEditMenuItem.Click += new System.EventHandler(this.addPermissionsEditMenuItem_Click);
            // 
            // deletePermissionsEditMenuItem
            // 
            this.deletePermissionsEditMenuItem.Name = "deletePermissionsEditMenuItem";
            this.deletePermissionsEditMenuItem.Size = new System.Drawing.Size(125, 22);
            this.deletePermissionsEditMenuItem.Text = "Modificar";
            this.deletePermissionsEditMenuItem.Click += new System.EventHandler(this.updatePermissionsEditMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuItem1.Text = "Eliminar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.deletePermissionsEditMenuItem_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelButtons.Controls.Add(this.buttonInventory);
            this.panelButtons.Controls.Add(this.btnStoreProducts);
            this.panelButtons.Controls.Add(this.button2);
            this.panelButtons.Controls.Add(this.buttonInput);
            this.panelButtons.Controls.Add(this.buttonProducts);
            this.panelButtons.Controls.Add(this.button3);
            this.panelButtons.Controls.Add(this.buttonBinnacle);
            this.panelButtons.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelButtons.Location = new System.Drawing.Point(0, 23);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(800, 38);
            this.panelButtons.TabIndex = 1;
            this.panelButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonInventory
            // 
            this.buttonInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(34)))), ((int)(((byte)(16)))));
            this.buttonInventory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInventory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInventory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonInventory.Location = new System.Drawing.Point(367, 5);
            this.buttonInventory.Name = "buttonInventory";
            this.buttonInventory.Size = new System.Drawing.Size(85, 25);
            this.buttonInventory.TabIndex = 6;
            this.buttonInventory.TabStop = false;
            this.buttonInventory.Text = "Inventario";
            this.buttonInventory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonInventory.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonInventory.UseVisualStyleBackColor = false;
            this.buttonInventory.Click += new System.EventHandler(this.buttonInventory_Click);
            // 
            // btnStoreProducts
            // 
            this.btnStoreProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(34)))), ((int)(((byte)(16)))));
            this.btnStoreProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStoreProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStoreProducts.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStoreProducts.Location = new System.Drawing.Point(185, 5);
            this.btnStoreProducts.Name = "btnStoreProducts";
            this.btnStoreProducts.Size = new System.Drawing.Size(85, 25);
            this.btnStoreProducts.TabIndex = 5;
            this.btnStoreProducts.TabStop = false;
            this.btnStoreProducts.Text = "Ubicar";
            this.btnStoreProducts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStoreProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStoreProducts.UseVisualStyleBackColor = false;
            this.btnStoreProducts.Click += new System.EventHandler(this.btnStoreProducts_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(34)))), ((int)(((byte)(16)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(94, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 25);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Text = "Salida";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.ButtonOutput_Click);
            // 
            // buttonInput
            // 
            this.buttonInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(34)))), ((int)(((byte)(16)))));
            this.buttonInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInput.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInput.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonInput.Location = new System.Drawing.Point(5, 5);
            this.buttonInput.Name = "buttonInput";
            this.buttonInput.Size = new System.Drawing.Size(85, 25);
            this.buttonInput.TabIndex = 0;
            this.buttonInput.TabStop = false;
            this.buttonInput.Text = "Entrada";
            this.buttonInput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonInput.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonInput.UseVisualStyleBackColor = false;
            this.buttonInput.Click += new System.EventHandler(this.ButtonInput_Click);
            // 
            // buttonProducts
            // 
            this.buttonProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(34)))), ((int)(((byte)(16)))));
            this.buttonProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProducts.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonProducts.Location = new System.Drawing.Point(458, 5);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(85, 25);
            this.buttonProducts.TabIndex = 3;
            this.buttonProducts.TabStop = false;
            this.buttonProducts.Text = "Productos";
            this.buttonProducts.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonProducts.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonProducts.UseVisualStyleBackColor = false;
            this.buttonProducts.Click += new System.EventHandler(this.ButtonProducts_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(34)))), ((int)(((byte)(16)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(276, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 25);
            this.button3.TabIndex = 2;
            this.button3.TabStop = false;
            this.button3.Text = "Reporte";
            this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.ButtonReports_Click);
            // 
            // buttonBinnacle
            // 
            this.buttonBinnacle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(34)))), ((int)(((byte)(16)))));
            this.buttonBinnacle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonBinnacle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBinnacle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBinnacle.Location = new System.Drawing.Point(549, 5);
            this.buttonBinnacle.Name = "buttonBinnacle";
            this.buttonBinnacle.Size = new System.Drawing.Size(85, 25);
            this.buttonBinnacle.TabIndex = 3;
            this.buttonBinnacle.TabStop = false;
            this.buttonBinnacle.Text = "Bitacora";
            this.buttonBinnacle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonBinnacle.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonBinnacle.UseVisualStyleBackColor = false;
            this.buttonBinnacle.Click += new System.EventHandler(this.ButtonBinnacle_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusToolStripStatusLabel,
            this.withoutInternetToolStripStatusLabel,
            this.withInternetToolStripStatusLabel,
            this.userToolStripStatusLabel,
            this.companyToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusToolStripStatusLabel
            // 
            this.statusToolStripStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statusToolStripStatusLabel.Name = "statusToolStripStatusLabel";
            this.statusToolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusToolStripStatusLabel.Text = "Status";
            // 
            // withoutInternetToolStripStatusLabel
            // 
            this.withoutInternetToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.withoutInternetToolStripStatusLabel.Image = global::InventaryWMS.Properties.Resources.icons8_wifi_apagado_64;
            this.withoutInternetToolStripStatusLabel.Name = "withoutInternetToolStripStatusLabel";
            this.withoutInternetToolStripStatusLabel.Size = new System.Drawing.Size(16, 17);
            this.withoutInternetToolStripStatusLabel.Text = "toolStripStatusLabel2";
            // 
            // withInternetToolStripStatusLabel
            // 
            this.withInternetToolStripStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.withInternetToolStripStatusLabel.Image = global::InventaryWMS.Properties.Resources.icons8_wi_fi_conectado_64;
            this.withInternetToolStripStatusLabel.Name = "withInternetToolStripStatusLabel";
            this.withInternetToolStripStatusLabel.Size = new System.Drawing.Size(16, 17);
            this.withInternetToolStripStatusLabel.Text = "toolStripStatusLabel3";
            // 
            // userToolStripStatusLabel
            // 
            this.userToolStripStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.userToolStripStatusLabel.Image = global::InventaryWMS.Properties.Resources.icons8_usuario_64;
            this.userToolStripStatusLabel.Name = "userToolStripStatusLabel";
            this.userToolStripStatusLabel.Size = new System.Drawing.Size(46, 17);
            this.userToolStripStatusLabel.Text = "User";
            // 
            // companyToolStripStatusLabel
            // 
            this.companyToolStripStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.companyToolStripStatusLabel.Image = global::InventaryWMS.Properties.Resources.icons8_empresa_64;
            this.companyToolStripStatusLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.companyToolStripStatusLabel.Name = "companyToolStripStatusLabel";
            this.companyToolStripStatusLabel.Size = new System.Drawing.Size(73, 17);
            this.companyToolStripStatusLabel.Text = "company";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelContainer.Controls.Add(this.panel1);
            this.panelContainer.Location = new System.Drawing.Point(0, 59);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 367);
            this.panelContainer.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.BackgroundImage = global::InventaryWMS.Properties.Resources.grupoabg;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(145, 127);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 112);
            this.panel1.TabIndex = 3;
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // transferenciasToolStripMenuItem
            // 
            this.transferenciasToolStripMenuItem.Name = "transferenciasToolStripMenuItem";
            this.transferenciasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.transferenciasToolStripMenuItem.Text = "Transferencias";
            this.transferenciasToolStripMenuItem.Click += new System.EventHandler(this.transferenciasToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panelContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Warehouse Management System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.ToolStripDropDownButton toolArchive;
        private System.Windows.Forms.ToolStripDropDownButton toolConfiguration;
        private System.Windows.Forms.ToolStripDropDownButton toolEdit;
        private System.Windows.Forms.Button buttonBinnacle;
        private System.Windows.Forms.Button buttonProducts;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonInput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel withoutInternetToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel withInternetToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel userToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel companyToolStripStatusLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ToolStripMenuItem systemConfigurationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambioClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permissionsEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addPermissionsEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePermissionsEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem userEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addEmailEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateEmailEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEmailEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productEditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandEditMenuItem;
        private ToolStripMenuItem destinationsEditMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem inveToolStripMenuItem;

        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem transferenciasToolStripMenuItem;
         private ToolStripMenuItem permisosToolStripMenuItem;
        private ToolStripMenuItem inventarioToolStripMenuItem1;
        private ToolStripMenuItem transferenciasToolStripMenuItem1;
        private Button btnStoreProducts;
        private Button buttonInventory;
        private ToolStripMenuItem proToolStripMenuItem;
        private ToolStripMenuItem asignarToolStripMenuItem;
    }
}

