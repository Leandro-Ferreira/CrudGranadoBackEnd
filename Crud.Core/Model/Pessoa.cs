using System.Text.RegularExpressions;

namespace Crud.Core.Model
{
    public class Pessoa
    {
        public Pessoa(string nome, string cpf, string email, string telefone)
        {
            Nome     = ValidarNome(nome);
            Cpf      = ValidarCPF(cpf);
            Email    = ValidarEmail(email);
            Telefone = ValidarTelefone(telefone);
        }

        public Pessoa(int id, string nome, string cpf, string email, string telefone)
        {
            Id       = id;
            Nome     = ValidarNome(nome);
            Cpf      = ValidarCPF(cpf);
            Email    = ValidarEmail(email);
            Telefone = ValidarTelefone(telefone);
        }

        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Cpf { get; private set; }

        public string Email { get; private set; }

        public string Telefone { get; private set; }



        private string ValidarNome(string nome)
        {
            Regex validarNomeRegex = new("[A-Za-zÀ-ÿçâãóéáí]{3}");

            if(validarNomeRegex.IsMatch(nome))
            {
                return nome;
            }

            throw new Exception("Nome inválido!");
        }

        private string ValidarCPF(string cpf)
        {
            Regex valdarCPFRegex = new(@"^[0-9]{3}.[0-9]{3}.[0-9]{3}-[0-9]{2}");

            if(valdarCPFRegex.IsMatch(cpf) && ValidarDigitoCPF(cpf))
            {
                return cpf;
            }

            throw new Exception("CPF inválido!");
        }

        private bool ValidarDigitoCPF(string cpf) 
        {
            string new_cpf = "";

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cpf.Length; i++)
            {
                if (isDigito(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CPF para 11 digitos considerando o digito verificador e completando com zeros a esquerda
            new_cpf = Convert.ToInt64(new_cpf).ToString("D11");

            // Verifica se o cpf informado tem os 11 digitos 
            if (new_cpf.Length > 11)
            {
                return false;
            }

            // Calcula o digito do CPF e compara com o digito informado
            if (CalculaDigCPF(new_cpf.Substring(0, 9)) == new_cpf.Substring(9, 2))
            {
                return true;
            }

            return false;
        }
        public static string CalculaDigCPF(string cpf)
        {
            // Declara variaveis para uso
            string new_cpf = "";
            string digito = "";
            int Aux1 = 0;
            int Aux2 = 0;

            // Retira carcteres invalidos não numericos da string
            for (int i = 0; i < cpf.Length; i++)
            {
                if (isDigito(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }

            // Ajusta o Tamanho do CPF para 9 digitos completando com zeros a esquerda
            new_cpf = Convert.ToInt64(new_cpf).ToString("D9");

            // Caso o tamanho do CPF informado for maior que 9 digitos retorna nulo
            if (new_cpf.Length > 9)
            {
                return null;
            }

            // Calcula o primeiro digito do CPF
            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (10 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            // Carrega o primeiro digito na variavel digito
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }

            // Adiciona o primeiro digito ao final do CPF para calculo do segundo digito
            new_cpf += digito;

            // Calcula o segundo digito do CPF
            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (11 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            // Carrega o segundo digito na variavel digito
            if (Aux2 > 9)
            {
                digito += "0";
            }
            else
            {
                digito += Aux2.ToString();
            }

            return digito;
        }

        private static Boolean isDigito(string digito)
        {
            return Int32.TryParse(digito, out int n);
        }

        private string ValidarEmail(string email)
        {
            Regex validarEmailRegex = new ("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])");

            if (validarEmailRegex.IsMatch(email))
            {
                return email;
            }

            throw new Exception("Email inválido!");
        }

        private string ValidarTelefone(string  telefone)
        {
            Regex validarTelefoneRegex = new(@"^\([\d]{2}\)[\d]{4}\-[\d]{4,5}$");

            if (validarTelefoneRegex.IsMatch(telefone))
            {
                return telefone;
            }

            throw new Exception("Telefone inválido!");
        }

    }
}
