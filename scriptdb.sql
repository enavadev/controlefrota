/*
    Nome do Banco: ControleVeiculos
    Obs: Caso deseje colocar outro nome para o banco é só alterar na connectionString do appsettiongs.jspn
*/

CREATE TABLE Veiculo(
    Id                  int             IDENTITY(1,1),
    Tipo                tinyint         NOT NULL,
    Placa               varchar(8)      NULL,
    Chassi              varchar(20)     NULL,
    Cor                 varchar(20)     NULL,
    Passageiros         tinyint         NULL,
    CONSTRAINT veiculospk PRIMARY KEY NONCLUSTERED (Id)
)
