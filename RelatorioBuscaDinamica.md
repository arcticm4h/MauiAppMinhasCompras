# Relatorio: busca dinamica de produtos

## Desafios encontrados

O principal desafio foi manter a lista da tela sincronizada com os dados do banco SQLite enquanto o usuario digita no campo de busca. Para resolver isso, a tela passou a usar uma `ObservableCollection<Produto>` como fonte do `CollectionView`. Assim, sempre que a pesquisa retorna novos resultados, a colecao e limpa e preenchida novamente, fazendo a interface atualizar automaticamente.

Outro ponto importante foi recarregar os produtos quando a tela volta a aparecer apos um cadastro. O metodo `OnAppearing` foi usado para buscar os dados novamente no banco, garantindo que um produto recem-cadastrado apareca na lista sem precisar reiniciar o aplicativo.

## Como a IA ajudou

A IA ajudou a identificar onde a lista deveria ser atualizada, como aplicar `ObservableCollection` no contexto do .NET MAUI e como ligar a busca dinamica ao evento `TextChanged` do `SearchBar`. Tambem auxiliou na organizacao do codigo, separando a rotina de carregamento dos produtos em um metodo reutilizavel.

Com isso, o codigo ficou mais simples de entender: a tela chama o banco, atualiza a colecao observavel e o MAUI reflete as mudancas automaticamente na interface.

## Melhorias futuras

Algumas melhorias possiveis sao:

- Implementar um pequeno atraso na busca para evitar consultas ao banco a cada tecla digitada.
- Permitir buscar por outros campos, como preco ou quantidade.
- Adicionar edicao e exclusao diretamente na lista.
- Melhorar a formatacao de moeda usando a cultura do dispositivo.
- Criar uma camada de ViewModel para separar melhor regras de tela e acesso aos dados.
