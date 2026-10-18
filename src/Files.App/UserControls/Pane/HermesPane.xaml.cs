using Microsoft.UI.Xaml.Controls;
using System;

namespace Files.App.UserControls.Pane
{
	public sealed partial class HermesPane : UserControl
	{
		public HermesPane()
		{
			this.InitializeComponent();
			Loaded += HermesPane_Loaded;
		}

		private async void HermesPane_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
		{
			try
			{
				await HermesWebView.EnsureCoreWebView2Async();
				HermesWebView.CoreWebView2.Navigate("http://192.168.178.153:9119/");
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"[HermesPane Error] {ex.Message}");
			}
		}

		public void UpdateFolderContext(string folderPath)
		{
			if (!string.IsNullOrEmpty(folderPath))
			{
				CurrentFolderText.Text = System.IO.Path.GetFileName(folderPath);
			}
		}
	}
}
