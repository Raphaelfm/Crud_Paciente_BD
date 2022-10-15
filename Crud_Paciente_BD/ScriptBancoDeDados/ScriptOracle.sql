--Delecoes
DROP TABLE endereco;
DROP TABLE medico;
DROP TABLE consulta;
DROP TABLE paciente;

-- Formando estrutura para tabela basedados_pacientes.endereco
CREATE TABLE endereco (
  id_endereco int GENERATED ALWAYS AS IDENTITY NOT NULL,
  logradouro varchar(45) NULL,
  numero int DEFAULT NULL,
  complemento varchar(45) NULL,
  bairro varchar(45) NULL,
  municipio varchar(45) NULL,
  uf varchar(2) NULL,
  cep varchar(10) NULL,
  PRIMARY KEY (id_endereco)
);

create sequence id_endereco;

-- Formando dados para a tabela basedados_pacientes.endereco:
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(1, 'Brodway', 55, '', 'Campo Grande', 'Cariacica', 'ES', '29155-845');
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(2, 'Avenida Obed', 189, '', 'Campo Verde', 'Cariacica', 'ES', '29155-845');
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(3, 'Jose Sete', 300, '', 'Cariacica Sede', 'Cariacica', '', '29135-896');
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(4, 'Uma rua', 23, 'Casa', 'Campo Verde', 'Cariacica', 'ES', '29111111');
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(5, 'Uma rua', 23, 'Casa', 'Campo Verde', 'Cariacica', 'ES', '29111233');
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(6, 'Rua dos medicos', 100, 'Predio', 'Centro', 'Vitoria', 'ES', '29546876');
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(7, 'Rua dos medicos', 100, 'Predio', 'Centro', 'Vitoria', 'ES', '29100100');
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(8, 'Rua dos medicos', 100, 'Predio', 'Centro', 'Vitoria', 'ES', '29132596');
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(9, 'Avenida Brasil', 55, 'Triplex', 'Sitio', 'Atibaia', 'SP', '63569897');
INSERT INTO endereco (id_endereco, logradouro, numero, complemento, bairro, municipio, uf, cep) VALUES
(10, 'Avenida Brasil', 13, 'Triplex', 'Sitio', 'Atibaia', 'SP', '63963659');


-- Formando estrutura para tabela basedados_pacientes.medico
CREATE TABLE medico (
  id_medico int GENERATED ALWAYS AS IDENTITY NOT NULL,
  nome varchar(45) NOT NULL,
  crm varchar(20) NOT NULL,
  celular varchar(17) NOT NULL,
  id_endereco int NOT NULL,
  PRIMARY KEY (id_medico),  
  CONSTRAINT medico_ibfk FOREIGN KEY (id_endereco) REFERENCES endereco (id_endereco) ON DELETE CASCADE
);


create sequence id_medico;

-- Formando dados para a tabela basedados_pacientes.medico
INSERT INTO medico (id_medico, nome, crm, celular, id_endereco) VALUES
(1, 'Luiz Inacio Squid Da Silva', 'PT13', '(27) 96599-9636', 10);


-- Formando estrutura para tabela basedados_pacientes.paciente
CREATE TABLE paciente (
  id_paciente int GENERATED ALWAYS AS IDENTITY NOT NULL,
  nome varchar(45) NOT NULL,
  dt_nasc varchar(10) NOT NULL,
  sexo varchar(1) DEFAULT NULL,
  cpf varchar(17) NOT NULL,
  celular varchar(17) DEFAULT NULL,
  email varchar(45) DEFAULT NULL,
  id_endereco int NOT NULL,
  PRIMARY KEY (id_paciente),
  CONSTRAINT paciente_ibfk FOREIGN KEY (id_endereco) REFERENCES endereco (id_endereco) ON DELETE CASCADE
);

create sequence id_paciente;

-- Formando dados para a tabela basedados_pacientes.paciente:
INSERT INTO paciente (id_paciente, nome, dt_nasc, sexo, cpf, celular, email, id_endereco) VALUES
(1, 'John Travolta', '01/01/1950', 'M', '123,456,789-10', '(27) 99988-7766', 'travolta@hollywood.com', 1);
INSERT INTO paciente (id_paciente, nome, dt_nasc, sexo, cpf, celular, email, id_endereco) VALUES
(2, 'Anjelina Jolie', '01/03/1970', 'F', '123,445,678-91', '(27) 99889-9889', 'jolie@hollywood.com', 2);
INSERT INTO paciente (id_paciente, nome, dt_nasc, sexo, cpf, celular, email, id_endereco) VALUES
(3, 'Vannila Ice', '20/09/1962', 'M', '123,654,987-55', '(27) 96335-6978', 'ice.vannila@music.com', 3);
INSERT INTO paciente (id_paciente, nome, dt_nasc, sexo, cpf, celular, email, id_endereco) VALUES
(5, 'Aristoteles Bidden', '01/01/1400', 'M', '123,456,987-65', '(27) 999999999', 'pensador@antigasso.com', 5);
   
-- Formando estrutura para tabela basedados_pacientes.consulta
CREATE TABLE consulta (
  id_consulta int GENERATED ALWAYS AS IDENTITY NOT NULL,
  id_medico int NOT NULL,
  id_paciente int NOT NULL,
  descricao_consulta varchar(200) NOT NULL,
  dt_consulta varchar(10) NOT NULL,
  PRIMARY KEY (id_consulta),
  CONSTRAINT medico_fk FOREIGN KEY (id_medico) REFERENCES medico (id_medico),
  CONSTRAINT paciente_fk FOREIGN KEY (id_paciente) REFERENCES paciente (id_paciente)
);

create sequence id_consulta;

-- Formando dados para a tabela basedados_pacientes.consulta:
INSERT INTO consulta (id_medico, id_paciente, descricao_consulta, dt_consulta) VALUES
(1, 2, 'Dores de cabeca constantes', '20/10/2022');
INSERT INTO consulta (id_medico, id_paciente, descricao_consulta, dt_consulta) VALUES
(1, 3, 'Sintomas de dengue', '20/10/2022');
INSERT INTO consulta (id_medico, id_paciente, descricao_consulta, dt_consulta) VALUES
(1, 1, 'Braço quebrado', '20/10/2022');
