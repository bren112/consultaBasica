using Supabase;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetEnv;

namespace umaConsulta
{
    public partial class Form1 : Form
    {
        private Supabase.Client _supabase;

        public Form1()
        {
            InitializeComponent();

            try
            {
                // Carrega os dados do .env
                DotNetEnv.Env.Load();
                string url = DotNetEnv.Env.GetString("SUPABASE_URL");
                string key = DotNetEnv.Env.GetString("SUPABASE_KEY");

                // Inicializa a conexão
                _supabase = new Supabase.Client(url, key);
            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar o .env: " + ex.Message);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Busca os dados no Supabase usando o molde Atletas
                var resposta = await _supabase.From<Atletas>().Get();


                dgvAtletas.AutoGenerateColumns = false; // assumir o controle das colunas

                //selecionar manualmente (apenas as q eu qro)
                dgvAtletas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID" });
                dgvAtletas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome do Atleta" });
                dgvAtletas.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Modalidade", HeaderText = "Esporte" });

                // manda os dados para a tabela
                dgvAtletas.DataSource = resposta.Models;



            } catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados: " + ex.Message);
            }
        }

    }
}