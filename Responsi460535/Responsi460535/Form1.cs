using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Responsi460535
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection con = new connection();
            con.getConn();

            loadData();
        }

        private NpgsqlCommand cmd;
        string sql;
        DataGridViewRow r;
        DataTable dt;
        private void loadData()
        {
            try
            {
                connection.conn.Open();

                sql = @"select * from empLoad()";
                cmd = new NpgsqlCommand(sql, connection.conn);
                dt = new DataTable();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                dgvEmp.DataSource = dt;

                connection.conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                connection.conn.Close();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (tbNama.Text != "")
            {
                try
                {
                    connection.conn.Open();
                    sql = @"select * from empInsert(:_nama, :_dep)";
                    cmd = new NpgsqlCommand(sql, connection.conn);
                    cmd.Parameters.AddWithValue("_nama", tbNama.Text);
                    cmd.Parameters.AddWithValue("_dep", cbDep.Text);

                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        MessageBox.Show("data berhasil ditambahkan");
                        connection.conn.Close();
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("data gagal ditambahkan");
                        connection.conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    connection.conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Isi semua data terlebih dahulu!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tbNama.Text != "")
            {
                try
                {
                    connection.conn.Open();
                    sql = @"select * from empEdit(:_nama, :_dep), :_id_karyawan";
                    cmd = new NpgsqlCommand(sql, connection.conn);
                    cmd.Parameters.AddWithValue("_nama", tbNama.Text);
                    cmd.Parameters.AddWithValue("_dep");

                    if ((int)cmd.ExecuteScalar() == 1)
                    {
                        MessageBox.Show("data berhasil diperbarui");
                        connection.conn.Close();
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("data gagal diperbarui");
                        connection.conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    connection.conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Data tidak boleh kosong!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void selectData(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvEmp.Rows[e.RowIndex];
                tbNama.Text = r.Cells["nama"].Value.ToString();
            }
        }
    }
}
