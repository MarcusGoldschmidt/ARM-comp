namespace ARM_comp.Interfaces
{
    public interface ITabelaIntervaloConfianca
    {
        double TabelaNormal(double valor);

        double TabelaTStudent(double grauLiberdade, double porcentagem);
    }
}