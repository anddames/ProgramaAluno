namespace Programa
{
    public struct Aluno
    {
        public string Nome {get; set;}
        public double Nota {get; set;} 
        public double Nota2 {get; set;}
        public double Media { get; set; }

        public static double calcularNota(double Nota, double Nota2)
        {   
            double mediaAluno = (Nota + Nota2)/2;
            return  mediaAluno;
        }
    }
}