using PGTLibrary.Models;

namespace PGTLibrary.Data
{
    public interface ISqlData
    {
        void addgastos(lagaymodel gastos);
        List<listgastos> listgastos();
        void register(string username, string firstName, string lastName, string password);
        listgastos showgastosdetails(DateOnly dateAdded);
        usermodel verify(string username, string password);
    }
}