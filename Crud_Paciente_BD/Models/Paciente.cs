using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Paciente_BD.Models
{
    internal class Paciente
    {
        //atributos
        public int id_paciente;
        public string nome;
        public string dt_nasc;
        public string sexo;
        public string cpf;
        public string celular;
        public string email;
        public int id_endereco;

        public ConexaoBanco banco;
        Endereco endereco = new Endereco();

        public Paciente()
        {
            this.id_paciente = 0;
            this.nome = "";
            this.dt_nasc = "";
            this.sexo = "";
            this.cpf = "";
            this.celular = "";
            this.email = "";
            this.id_endereco = 0;

            this.banco = new ConexaoBanco();
        }
        public void setId_paciente(int novo) { this.id_paciente = novo; }
        public void setNome(string novo) { this.nome = novo; }
        public void setDt_nasc(string novo) { this.dt_nasc = novo; }
        public void setSexo(string novo) { this.sexo = novo; }
        public void setCpf(string novo) { this.cpf = novo; }
        public void setCelular(string novo) { this.celular = novo; }
        public void setEmail(string novo) { this.email = novo; }
        public void setId_endereco(int novo) { this.id_endereco = novo; }

        public int getId_paciente() { return this.id_paciente; }
        public string getNome() { return this.nome; }
        public string getDt_nasc() { return this.dt_nasc; }
        public string getSexo() { return this.sexo; }
        public string getCpf() { return this.cpf; }
        public string getCelular() { return this.celular; }
        public string getEmail() { return this.email; }
        public int getId_endereco() { return this.id_endereco; }

        // CRIAR METODO PARA BUSCAR PACIENTES PARA O GRID
        public MySqlDataReader ListarPaciente()
        {
            this.banco.conectar();
            return this.banco.Query("select p.id_paciente, p.Nome, p.dt_nasc,p.sexo,p.CPF, p.celular, p.email," +
                " e.id_endereco, e.logradouro, e.numero,e.complemento, e.bairro, e.municipio, e.uf, e.cep from paciente p " +
                "join endereco e on p.id_endereco = e.id_endereco; ");
        }
        // CRIAR METODO PARA BUSCAR PACIENTES PELO BOTÃO OK
        public MySqlDataReader ListarPacientePorOk(string filtro)
        {
            this.banco.conectar();
            return this.banco.Query("select p.id_paciente, p.Nome,p.dt_nasc,p.sexo, p.CPF, p.celular, p.email, " +
                "e.id_endereco, e.logradouro, e.numero,e.complemento, e.bairro, e.municipio, e.uf, e.cep from paciente p " +
                "join endereco e on p.id_endereco = e.id_endereco where p.Nome like '%" + filtro + "%'; ");
        }
        // ---INSERIR---
        public void CadastrarPaciente()
        {
            this.banco.conectar();
            this.banco.nonQuery("INSERT INTO `basedados_pacientes`.`paciente` (`Nome`, `dt_nasc`,`sexo`," +
                "`CPF`, `celular`,`email`, `id_endereco`) VALUES ('" +
                this.getNome() + "', '" +
                this.getDt_nasc() + "', '" +
                this.getSexo() + "', '" +
                this.getCpf() + "', '" +
                this.getCelular() + "', '" +
                this.getEmail() + "', '" +
                this.getId_endereco() + "');");
            this.banco.close();
        }
        // ---ALTERAR---
        public void AlterarPaciente()
        {
            this.banco.conectar();
            this.banco.nonQuery("UPDATE paciente set nome='" + this.getNome() +
                "', dt_nasc='" + this.getDt_nasc() +
                "', sexo='" + this.getSexo() +
                "', cpf='" + this.getCpf() +
                "', celular='" + this.getCelular() +
                "', email='" + this.getEmail() +
                "' where id_paciente ='" + this.getId_paciente() + "';");
            this.banco.close();
        }
        // ---EXCLUIR---
        public void ExcluirPaciente()
        {
            this.banco.conectar();
            this.banco.nonQuery("Delete from paciente where id_paciente ='" + this.getId_paciente() + "'");
            this.banco.close();
        }

        public int QuantidadePacientes()
        {
            this.banco.conectar();
            int contagem = 0;
            var temp = this.banco.Query("SELECT COUNT(*) FROM PACIENTE;");
            while (temp.Read())
            {
                contagem = temp.GetInt32(0);
            }
            return contagem;
        }

        public List<Paciente> GetPacientes()
        {
            List<Paciente> lista = new List<Paciente>();
            List<Endereco> enderecos = new List<Endereco>();
            
            this.banco.conectar();
            var pacientes = ListarPaciente();

            try
            {
                while (pacientes.HasRows)
                {                    
                    while (pacientes.Read())
                    {
                        Paciente listaPaciente = new Paciente();
                        
                        listaPaciente.setId_paciente(pacientes.GetInt32(0));
                        listaPaciente.setNome(pacientes.GetString(1));
                        listaPaciente.setDt_nasc(pacientes.GetString(2));
                        listaPaciente.setSexo(pacientes.GetString(3));
                        listaPaciente.setCpf(pacientes.GetString(4));
                        listaPaciente.setCelular(pacientes.GetString(5));
                        listaPaciente.setEmail(pacientes.GetString(6));                        

                        lista.Add(listaPaciente);  
                    }
                    pacientes.NextResult();                    
                }
                
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }

            return lista;
        }

        public List<Endereco> GetEnderecosPacientes()
        {
            List<Endereco> lista = new List<Endereco>();

            this.banco.conectar();
            var enderecos = ListarPaciente();

            try
            {
                while (enderecos.HasRows)
                {
                    while (enderecos.Read())
                    {
                        Endereco listaEndereco = new Endereco();

                        listaEndereco.setId_endereco(enderecos.GetInt32(7));
                        listaEndereco.setLogradouro(enderecos.GetString(8));
                        listaEndereco.setNumero(enderecos.GetString(9));
                        listaEndereco.setComplemento(enderecos.GetString(10));
                        listaEndereco.setBairro(enderecos.GetString(11));
                        listaEndereco.setMunicipio(enderecos.GetString(12));
                        listaEndereco.setUf(enderecos.GetString(13));
                        listaEndereco.setCep(enderecos.GetString(14));

                        lista.Add(listaEndereco);
                    }
                    enderecos.NextResult();
                }
            }
            catch(MySqlException e)
            {
                Console.WriteLine(e);
            }
            

            return lista;
        }
    }
}
