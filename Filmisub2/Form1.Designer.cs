namespace Filmisub2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.Label lblDescription;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnFetch = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.Location = new System.Drawing.Point(12, 260);
            this.dataGridView1.Size = new System.Drawing.Size(600, 180);
            this.dataGridView1.TabIndex = 0;

            // Labels and TextBoxes
            int startY = 10;
            int labelX = 20;
            int textBoxX = 120;
            int spacingY = 30;

            // ID
            this.lblId.Location = new System.Drawing.Point(labelX, startY);
            this.lblId.Size = new System.Drawing.Size(80, 20);
            this.lblId.Text = "ID Selection:";
            this.txtId.Location = new System.Drawing.Point(textBoxX, startY);
            this.txtId.Size = new System.Drawing.Size(180, 20);

            // Title
            this.lblTitle.Location = new System.Drawing.Point(labelX, startY + spacingY);
            this.lblTitle.Size = new System.Drawing.Size(80, 20);
            this.lblTitle.Text = "Title:";
            this.txtTitle.Location = new System.Drawing.Point(textBoxX, startY + spacingY);
            this.txtTitle.Size = new System.Drawing.Size(180, 20);

            // Director
            this.lblDirector.Location = new System.Drawing.Point(labelX, startY + spacingY * 2);
            this.lblDirector.Size = new System.Drawing.Size(80, 20);
            this.lblDirector.Text = "Director:";
            this.txtDirector.Location = new System.Drawing.Point(textBoxX, startY + spacingY * 2);
            this.txtDirector.Size = new System.Drawing.Size(180, 20);

            // Year
            this.lblYear.Location = new System.Drawing.Point(labelX, startY + spacingY * 3);
            this.lblYear.Size = new System.Drawing.Size(80, 20);
            this.lblYear.Text = "Year:";
            this.txtYear.Location = new System.Drawing.Point(textBoxX, startY + spacingY * 3);
            this.txtYear.Size = new System.Drawing.Size(180, 20);

            // Genre
            this.lblGenre.Location = new System.Drawing.Point(labelX, startY + spacingY * 4);
            this.lblGenre.Size = new System.Drawing.Size(80, 20);
            this.lblGenre.Text = "Genre:";
            this.txtGenre.Location = new System.Drawing.Point(textBoxX, startY + spacingY * 4);
            this.txtGenre.Size = new System.Drawing.Size(180, 20);

            // Description
            this.lblDescription.Location = new System.Drawing.Point(labelX, startY + spacingY * 5);
            this.lblDescription.Size = new System.Drawing.Size(80, 20);
            this.lblDescription.Text = "Description:";
            this.txtDescription.Location = new System.Drawing.Point(textBoxX, startY + spacingY * 5);
            this.txtDescription.Size = new System.Drawing.Size(180, 20);

            // Buttons
            this.btnAdd.Text = "Add";
            this.btnAdd.Location = new System.Drawing.Point(350, 10);
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Text = "Update";
            this.btnUpdate.Location = new System.Drawing.Point(350, 50);
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Text = "Delete";
            this.btnDelete.Location = new System.Drawing.Point(350, 90);
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnFetch.Text = "Fetch by ID";
            this.btnFetch.Location = new System.Drawing.Point(350, 130);
            this.btnFetch.Size = new System.Drawing.Size(100, 30);
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // Clear Button
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClear.Text = "Clear Fields";
            this.btnClear.Location = new System.Drawing.Point(350, 170);
            this.btnClear.Size = new System.Drawing.Size(100, 30);
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.Controls.Add(this.btnClear);

            // Form
            this.ClientSize = new System.Drawing.Size(630, 460);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtDirector);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDirector);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblDescription);
            this.Text = "Film Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
