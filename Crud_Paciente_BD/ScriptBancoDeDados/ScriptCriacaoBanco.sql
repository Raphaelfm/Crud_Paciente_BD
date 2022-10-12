create database basedados_pacientes;

use basedados_pacientes;

CREATE TABLE `endereco` (
  `id_endereco` int(11) NOT NULL AUTO_INCREMENT,
  `logradouro` varchar(45) DEFAULT NULL,
  `numero` int(11) DEFAULT NULL,
  `complemento` varchar(45) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `municipio` varchar(45) DEFAULT NULL,
  `uf` varchar(2) DEFAULT NULL,
  `cep` varchar(10) default NULL,
  PRIMARY KEY (`id_endereco`)
);
CREATE TABLE `paciente` (
  `id_paciente` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `dt_nasc` varchar(10) NOT NULL,
  `sexo` varchar(1) DEFAULT NULL,
  `cpf` varchar(17) NOT NULL,
  `celular` varchar(17) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `id_endereco` int(11) NOT NULL,
  PRIMARY KEY (`id_paciente`),
  KEY `id_endereco` (`id_endereco`),
  CONSTRAINT `paciente_ibfk` FOREIGN KEY (`id_endereco`) REFERENCES `endereco` (`id_endereco`) ON DELETE CASCADE ON UPDATE CASCADE
);
CREATE TABLE `login` (
  `usuario` varchar(20) NOT NULL,
  `senha` varchar(10) NOT NULL,
  PRIMARY KEY (`usuario`)
);

CREATE TABLE `medico`(
  `id_medico` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `crm` varchar(20) NOT NULL,
  `celular` varchar(17) NOT NULL, 
  `id_endereco` int(11) NOT NULL,
  PRIMARY KEY(`id_medico`),
  KEY `id_endereco` (`id_endereco`),
  CONSTRAINT `medico_ibfk` FOREIGN KEY (`id_endereco`) REFERENCES `endereco` (`id_endereco`) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE `consulta`(
  `id_consulta` int (11) NOT NULL AUTO_INCREMENT,
  `id_medico` int (11) NOT NULL,
  `id_paciente` int (11) NOT NULL,
  `descricao_consulta` varchar(200) NOT NULL,
  PRIMARY KEY(`id_consulta`),
  CONSTRAINT `medico_fk` FOREIGN KEY (`id_medico`) REFERENCES `medico` (`id_medico`),
  CONSTRAINT `paciente_fk` FOREIGN KEY (`id_paciente`) REFERENCES `paciente` (`id_paciente`)
);

insert into login  values ('adm', 'adm');
