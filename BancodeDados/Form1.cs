using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.IO;
using System.Data.SQLite;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace BancodeDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            #region SQLite
            /*
            string BasedeDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConection = @"Data Source = " + BasedeDados + "; Version = 3";

            if(!File.Exists(BasedeDados))
            {
                SQLiteConnection.CreateFile(BasedeDados);
            }

            SQLiteConnection conexao = new SQLiteConnection(strConection);

            try
            {
                conexao.Open();
                labelResultado.Text = "Conectdo com sucesso ao SQlite!";
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Erro ao Conectar SQlite \n" + ex;
            }
            finally { conexao.Close(); }
            */
            #endregion

            #region MySQL
            
            string strConnection = @"server=localhost;User Id=root;database=mysqldb;password=";

            MySqlConnection conexao = new MySqlConnection(strConnection);

            try
            {
                conexao.Open();
                labelResultado.Text = "Conexão ao MySQL realizada com sucesso!";

                MySqlCommand comando = new MySqlCommand();

                comando.Connection = conexao;

                comando.CommandText = "CREATE DATABASE IF NOT EXISTS MySqlDB";

                comando.ExecuteNonQuery();
                labelResultado.Text = "Base de Dados criada com sucesso!!";
                comando.Dispose();
                
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Erro ao Conectar ao MySQL \n" + ex;
            }
            finally { conexao.Close(); }
            
            #endregion
        }

        private void btnCriarTabela_Click(object sender, EventArgs e)
        {
            #region SQLite
            /*
            string BasedeDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConnection = @"Data Source = " + BasedeDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(strConnection);


            try
            {
                conexao.Open();

                SQLiteCommand comando = new SQLiteCommand();
                comando.Connection = conexao;

                comando.CommandText = "CREATE TABLE pessoas ( id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE NOT NULL, nome VARCHAR(50), email VARCHAR(50))";
                comando.ExecuteNonQuery();

                labelResultado.Text = "Tabela criada com sucesso!";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel criar a tabela pessoas! \n" + ex;
                
            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region MySQl

            string strConnection = @"server=localhost;User Id=root;database=mysqldb;password=";

            MySqlConnection conexao = new MySqlConnection(strConnection);


            try
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexao;

                comando.CommandText = "CREATE TABLE pessoas (id INTEGER NOT NULL AUTO_INCREMENT, nome VARCHAR(50), email VARCHAR(50), PRIMARY KEY (id))";
                comando.ExecuteNonQuery();

                labelResultado.Text = "Tabela criada com sucesso!";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel criar a tabela pessoas! \n" + ex;

            }
            finally
            {
                conexao.Close();
            }

            #endregion
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            #region SQLite
            /*
            string BasedeDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConnection = @"Data Source = " + BasedeDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(strConnection);

            try
            {
                conexao.Open();

                SQLiteCommand comando = new SQLiteCommand();
                comando.Connection = conexao;

                int id = new Random(DateTime.Now.Millisecond).Next(0, 1000);
                string nome = txtNome.Text; 
                string email = txtEmail.Text;

                comando.CommandText = String.Format("INSERT INTO pessoas VALUES ('{0}','{1}','{2}')", id,nome, email);
                comando.ExecuteNonQuery();

                labelResultado.Text = "Valores inseridos com sucesso na tabela pessoas!";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel inserir os valores na tabela pessoas! \n" + ex;

            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region MySQL
            
            string strConnection = @"server=localhost;User Id=root;database=mysqldb;password=";

            MySqlConnection conexao = new MySqlConnection(strConnection);

            try
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexao;

                int id = new Random(DateTime.Now.Millisecond).Next(0, 1000);
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                comando.CommandText = String.Format("INSERT INTO pessoas VALUES ('{0}','{1}', '{2}')",id, nome, email);
                comando.ExecuteNonQuery();

                labelResultado.Text = "Valores inseridos com sucesso na tabela pessoas!";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel inserir os valores na tabela pessoas! \n" + ex;

            }
            finally
            {
                conexao.Close();
            }
            
            #endregion
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            #region SQLite
            /*
            string BasedeDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConnection = @"Data Source = " + BasedeDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(strConnection);

            try
            {
                String query = "SELECT * FROM pessoas";

                if (txtNome.Text != "")
                {
                    query = "SELECT * FROM pessoas WHERE nome LIKE '" + txtNome.Text + "'";
                }

                DataTable dados = new DataTable();
                SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, strConnection);

                conexao.Open();

                adaptador.Fill(dados);

                lista.Rows.Clear();

                foreach (DataRow item in dados.Rows)
                {
                    lista.Rows.Add(item.ItemArray);
                }
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel procurar os dados na tabela pessoas! \n" + ex;

            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region MySQL
            
            string strConnection = @"server=localhost;User Id=root;database=mysqldb;password=";

            MySqlConnection conexao = new MySqlConnection(strConnection);

            try
            {
                String query = "SELECT * FROM pessoas";

                if (txtNome.Text != "")
                {
                    query = "SELECT * FROM pessoas WHERE nome LIKE '" + txtNome.Text + "'";
                }

                DataTable dados = new DataTable();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, strConnection);

                conexao.Open();

                adaptador.Fill(dados);
                lista.Rows.Clear();

                foreach (DataRow item in dados.Rows)
                {
                    lista.Rows.Add(item.ItemArray);
                }
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel procurar os dados na tabela pessoas! \n" + ex;

            }
            finally
            {
                conexao.Close();
            }
            
            #endregion
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            #region SQLite
            /*
            string BasedeDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConnection = @"Data Source = " + BasedeDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(strConnection);

            try
            {
                conexao.Open();

                SQLiteCommand comando = new SQLiteCommand();
                comando.Connection = conexao;

                int id = (int)lista.SelectedRows[0].Cells[0].Value;
                comando.CommandText = String.Format("DELETE FROM pessoas WHERE id = '{0}'", id);

                comando.ExecuteNonQuery();

                labelResultado.Text = "Registo excluido com sucesso!!";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel excluir o dado na tabela pessoas! \n" + ex;

            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region MySQL
            
            string strConnection = @"server=localhost;User Id=root;database=mysqldb;password=";

            MySqlConnection conexao = new MySqlConnection(strConnection);

            try
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexao;

                int id = (int)lista.SelectedRows[0].Cells[0].Value;
                comando.CommandText = String.Format("DELETE FROM pessoas WHERE id = '{0}'", id);

                comando.ExecuteNonQuery();

                labelResultado.Text = "Registo excluido com sucesso!!";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel excluir o dado na tabela pessoas! \n" + ex;

            }
            finally
            {
                conexao.Close();
            }
            
            #endregion
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            #region SQLite
            /*
            string BasedeDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConnection = @"Data Source = " + BasedeDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(strConnection);

            try
            {
                conexao.Open();

                SQLiteCommand comando = new SQLiteCommand();
                comando.Connection = conexao;

                //int id = (int)lista.SelectedRows[0].Cells[0].Value;
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                //comando.CommandText = String.Format("UPDATE pessoas SET nome = '{0}', email = '{1}' WHERE id = '{2}'",nome, email, id);

                //comando.ExecuteNonQuery();

                labelResultado.Text = id.ToString();
                //comando.Dispose();
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel alterar os dados na tabela pessoas! \n" + ex;

            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion
            
            #region MySQL
            
            string strConnection = @"server=localhost;User Id=root;database=mysqldb;password=";

            MySqlConnection conexao = new MySqlConnection(strConnection);

            try
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = conexao;

                int id = (int)lista.SelectedRows[0].Cells[0].Value;
                string nome = txtNome.Text;
                string email = txtEmail.Text;

                comando.CommandText = String.Format("UPDATE pessoas SET nome = '{0}', email = '{1}' WHERE id = '{2}'", nome, email, id);

                comando.ExecuteNonQuery();

                labelResultado.Text = "Registro alterado com sucesso!";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                labelResultado.Text = "Não foi possivel procurar os dados na tabela pessoas! \n" + ex;

            }
            finally
            {
                conexao.Close();
            }
            
            #endregion
        }
    }
}
