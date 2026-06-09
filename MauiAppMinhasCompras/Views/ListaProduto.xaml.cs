using System.Collections.ObjectModel;
using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ObservableCollection<Produto> Produtos { get; } = new();

    public ListaProduto()
    {
        InitializeComponent();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarProdutos();
    }

    private async void ToolbarItem_Clicked(object? sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new NovoProduto());
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private async void SearchBar_TextChanged(object? sender, TextChangedEventArgs e)
    {
        await CarregarProdutos(e.NewTextValue);
    }

    private async void Somar_Clicked(object? sender, EventArgs e)
    {
        double total = Produtos.Sum(p => p.Quantidade * p.Preco);
        await DisplayAlertAsync("Total da compra", $"Total: R$ {total:F2}", "OK");
    }

    private async Task CarregarProdutos(string? busca = null)
    {
        try
        {
            List<Produto> produtos = string.IsNullOrWhiteSpace(busca)
                ? await App.Db.GetAll()
                : await App.Db.Search(busca.Trim());

            Produtos.Clear();

            foreach (Produto produto in produtos)
            {
                Produtos.Add(produto);
            }

            AtualizarTotal();
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }

    private void AtualizarTotal()
    {
        double total = Produtos.Sum(p => p.Quantidade * p.Preco);
        lbl_total.Text = $"Total: R$ {total:F2}";
    }
}
