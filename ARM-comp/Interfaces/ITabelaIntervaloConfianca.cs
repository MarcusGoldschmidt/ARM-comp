namespace ARM_comp.Models.Interfaces
{
    public interface ITabelaIntervaloConfianca
    {
        double TabelaNormal(double valor);

        double TabelaTStudent(int grauLiberdade, double segundoValor);
    }
}