using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object? sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txt_descricao.Text) ||
                string.IsNullOrWhiteSpace(txt_quantidade.Text) ||
                string.IsNullOrWhiteSpace(txt_preco_unitario.Text))
            {
                await DisplayAlertAsync("Atencao", "Preencha todos os campos.", "Ok");
                return;
            }

            if (!double.TryParse(txt_quantidade.Text, out double quantidade) ||
                !double.TryParse(txt_preco_unitario.Text, out double preco))
            {
                await DisplayAlertAsync("Atencao", "Informe quantidade e preco validos.", "Ok");
                return;
            }

            Produto p = new()
            {
                Descricao = txt_descricao.Text.Trim(),
                Quantidade = quantidade,
                Preco = preco
            };

            await App.Db.Insert(p);
            await DisplayAlertAsync("Sucesso!", "Registro inserido", "Ok");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "Ok");
        }
    }
}
