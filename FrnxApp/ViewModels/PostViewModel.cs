using System.Collections.ObjectModel;
using System.Windows.Input;
using FrnxApp.Models;
using FrnxApp.Services;

namespace FrnxApp.ViewModels;

public class PostViewModel : BindableObject
{
    private readonly ApiService _api = new();
    public ObservableCollection<Post> Posts { get; set; } = new();

    public ICommand LoadCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand DeleteCommand { get; }

    public PostViewModel()
    {
        LoadCommand = new Command(async () => await LoadPosts());
        AddCommand = new Command(async () => {
            await _api.AddPost(new Post { Title = "Frnx Post", Content = "Modern UI content" });
            await LoadPosts();
        });
        DeleteCommand = new Command<Post>(async (p) => {
            await _api.DeletePost(p.Id);
            await LoadPosts();
        });
    }

    private async Task LoadPosts()
    {
        var data = await _api.GetPosts();
        Posts.Clear();
        foreach (var item in data) Posts.Add(item);
    }
}