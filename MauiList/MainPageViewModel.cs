using CommunityToolkit.Mvvm.ComponentModel;
using Sharpnado.CollectionView.Paging;
using Sharpnado.CollectionView.Services;
using Sharpnado.CollectionView.ViewModels;

namespace MauiList;

public partial class MainPageViewModel: ObservableObject
{

    [ObservableProperty] 
    private ObservableRangeCollection<DataTeste> _mensagens;
    public Paginator<DataTeste> MensagensPaginator { get; set; }

    private async Task<PageResult<DataTeste>> MaisMensagens(int pageNumber, int pageSize, bool ifRefresh)
    {
        await Task.Delay(2000);
        var retorno = new List<DataTeste>();
        for (int i = pageNumber; i < pageNumber + pageSize; i++)
        {
            retorno.Add(new DataTeste() { Contador = i, Desc = $"{i} - Descrição do {i}" });
        }

        if (ifRefresh || pageNumber == 1)
        {
            Mensagens = new ObservableRangeCollection<DataTeste>(retorno);
        }
        else
        {

            Mensagens.AddRange(retorno);
        }

        return new PageResult<DataTeste>(
            Mensagens.Count,
            Mensagens.ToList());
    }

    public MainPageViewModel()
    {
        Mensagens = new ObservableRangeCollection<DataTeste>();
        MensagensPaginator = new Paginator<DataTeste>(MaisMensagens,pageSize:25);
    }

    public async Task InitializaAsync()
    {
        await MensagensPaginator.LoadPage(1);
    }
}
public class DataTeste
{
    public int Contador { get; set; }
    public string Desc { get; set; }
}