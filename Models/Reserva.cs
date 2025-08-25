namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            bool ehPossivelHospedar = hospedes.Count > Suite.Capacidade; 
            if (!ehPossivelHospedar)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new Exception($"Não é possível hospedar essa quantidade de hóspedes na suite, a capacaidade da Suite escolhida é: {Suite.Capacidade}");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            int quantidadeDeHospedes = Hospedes.Count > 0 ? Hospedes.Count : 0;
            return quantidadeDeHospedes;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valorDaDiaria = Suite.ValorDiaria * DiasReservados;

            if (DiasReservados <= 0)
            {
                throw new Exception("A quantidade de dias reservados não pode ser menor ou igual a zero.");
            }

            if (valorDaDiaria > 0 && DiasReservados < 10)
            {
                return valorDaDiaria;
            }

            if (valorDaDiaria > 0 && DiasReservados >= 10)
            {
                return valorDaDiaria * 0.9m;
            }
            
            return 0;
        }
    }
}