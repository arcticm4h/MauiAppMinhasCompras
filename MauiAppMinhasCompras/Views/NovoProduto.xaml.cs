using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async Task ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Produto p = new Produto
			{
				Descricao = txt_descricao.Text,
				Quantidade = Convert.ToDouble(txt_quantidade.Text),
				Preco = Convert.ToDouble(txt_preco_unitario.Text)
			};

			await App.Db.Insert(p);
			await DisplayAlertAsync("Sucesso", "Registro inserido", "Ok");

		} catch(Exception ex)
		{
			await DisplayAlertAsync("Ops", ex.Message, "Ok");
		}
    }
}