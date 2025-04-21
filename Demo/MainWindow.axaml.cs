using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using Avalonia.Controls;
using Avalonia.Interactivity;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;

namespace Demo;

public partial class MainWindow : Window
{
    string DataFromApi = "";
    string EmailFromApi = "";
    string MobilePhoneFromApi = "";
    string SnilsFromApi = "";
    string InnFromApi = "";
    string IdentityCardFromApi = "";
    public MainWindow()
    {
        InitializeComponent();
    }
    //// Обработчик ФИО
    // private void SendFullNameTestResult_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var pattern = @"[^А-Яа-яЁё\s]";
    //     var validationResult = Regex.IsMatch(DataFromApi, pattern);
    //     ValidationResultTBlock.Text = validationResult ? "ФИО содержит запрещенные символы" : "ФИО не содержит запрещенные символы";
    //     
    //     using var doc = WordprocessingDocument.Open(@"TestCaseName.docx", true);
    //     var document = doc.MainDocumentPart.Document;
    //
    //     if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Result 1")) != null)
    //     {
    //         ReplaceNameTextTestCase("Result 1", validationResult, document);
    //     } else if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Result 2")) != null)
    //     {
    //         ReplaceNameTextTestCase("Result 2", validationResult, document);
    //     }
    //     
    // }
    //
    // private void ReplaceNameTextTestCase(string replacedText, bool validationResult, Document document)
    // {
    //     foreach (var text in document.Descendants<Text>())
    //     {
    //         if (text.Text == replacedText)
    //             text.Text = text.Text.Replace(replacedText, validationResult ? "Не успешно" : "Успешно");
    //         else if (text.Text == replacedText)
    //             text.Text = text.Text.Replace(replacedText, validationResult ? "Не успешно" : "Успешно");
    //     }
    // }
    //
    // private async void GetDataFromApi_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var httpClient = new HttpClient();
    //     var content = await httpClient.GetStringAsync("http://localhost:4444/TransferSimulator/fullName");
    //     var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
    //     DataFromApi = data["value"];
    //     DataFromApiTBlock.Text = DataFromApi;
    // }
    
    //// Обработчик Email
    // private void SendEmailTestResult_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var pattern = @"^[@\s]+@[^@\s]+\.[^@\s]+$";
    //     var validationResult = Regex.IsMatch(EmailFromApi, pattern);
    //     ValidationResultTBlock.Text = validationResult ? "Email корректен" : "Email некорректен";
    //
    //     using var doc = WordprocessingDocument.Open(@"TestCaseEmail.docx", true);
    //     var document = doc.MainDocumentPart.Document;
    //
    //     if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Result 1")) != null)
    //     {
    //         ReplaceEmailTextTestCase("Result 1", validationResult, document);
    //     } else if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Result 2")) != null)
    //     {
    //         ReplaceEmailTextTestCase("Result 2", validationResult, document);
    //     }
    // }
    //
    // private void ReplaceEmailTextTestCase(string replacedText, bool validationResult, Document document)
    // {
    //     foreach (var text in document.Descendants<Text>())
    //     {
    //         if (text.Text.Contains(replacedText))
    //         {
    //             text.Text = text.Text.Replace(replacedText, validationResult ? "Успешно" : "Не успешно");
    //         }
    //     }
    // }
    //
    // private async void GetEmailFromApi_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var httpClient = new HttpClient();
    //     var content = await httpClient.GetStringAsync("http://localhost:4444/TransferSimulator/email");
    //     var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
    //     DataFromApi = data["value"];
    //     DataFromApiTBlock.Text = DataFromApi;
    // }

    //// Обработчик мобильный телефон
    private void SendMobilePhoneTestResult_OnClick(object? sender, RoutedEventArgs e)
    {
        var pattern = @"^\+7 \d{3} \d{3}-\d{2}-\d{2}$";
        var validationResult = Regex.IsMatch(MobilePhoneFromApi, pattern);
        ValidationResultTBlock.Text = validationResult ? "Мобильный телефон корректен" : "Мобильный телефон некорректен";
    
        using var doc = WordprocessingDocument.Open(@"TestCase.docx", true);
        var document = doc.MainDocumentPart.Document;
    
        if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Result 1")) != null)
        {
            ReplaceMobilePhoneTextTestCase("Result 1", validationResult, document);
        } else if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Result 2")) != null)
        {
            ReplaceMobilePhoneTextTestCase("Result 2", validationResult, document);
        }
    }
    
    private void ReplaceMobilePhoneTextTestCase(string replacedText, bool validationResult, Document document)
    {
        foreach (var text in document.Descendants<Text>())
        {
            if (text.Text.Contains(replacedText))
            {
                text.Text = text.Text.Replace(replacedText, validationResult ? "Успешно" : "Не успешно");
            }
        }
    }
    // http://localhost:4444/TransferSimulator/mobilePhone
    private async void GetMobilePhoneFromApi_OnClick(object? sender, RoutedEventArgs e)
    {
        var httpClient = new HttpClient();
        var content = await httpClient.GetStringAsync("http://10.30.12.163:4444/TransferSimulator/mobilePhone");
        var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
        MobilePhoneFromApi = data["value"];
        DataFromApiTBlock.Text = MobilePhoneFromApi;
    }

    //// Обработчик СНИСЛ
    // private void SendSnilsTestResult_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var pattern = @"^\d{11}$";
    //     var validationResult = Regex.IsMatch(SnilsFromApi, pattern);
    //     ValidationResultTBlock.Text = validationResult ? "СНИЛС корректен" : "СНИЛС некорректен";
    //
    //     using var doc = WordprocessingDocument.Open(@"TestCaseSnils.docx", true);
    //     var document = doc.MainDocumentPart.Document;
    //
    //     if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Result 1")) != null)
    //     {
    //         ReplaceSnilsTextTestCase("Result 1", validationResult, document);
    //     }
    //     else if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Result 2")) != null)
    //     {
    //         ReplaceSnilsTextTestCase("Result 2", validationResult, document);
    //     }
    // }
    //
    // private void ReplaceSnilsTextTestCase(string replacedText, bool validationResult, Document document)
    // {
    //     foreach (var text in document.Descendants<Text>())
    //     {
    //         if (text.Text.Contains(replacedText))
    //         {
    //             text.Text = text.Text.Replace(replacedText, validationResult ? "Успешно" : "Не успешно");
    //         }
    //     }
    // }
    //
    // private async void GetSnilsFromApi_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var httpClient = new HttpClient();
    //     var content = await httpClient.GetStringAsync("http://localhost:4444/TransferSimulator/snils");
    //     var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
    //     DataFromApi = data["value"];
    //     DataFromApiTBlock.Text = DataFromApi;
    // }
    
    //// Обработчик ИНН
    // private void SendInnTestResult_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var pattern = @"^\d{10}$";
    //     var validationResult = Regex.IsMatch(InnFromApi, pattern);
    //     InnValidationResultTBlock.Text = validationResult ? "ИНН корректен" : "ИНН некорректен";
    //
    //     using var doc = WordprocessingDocument.Open(@"TestCaseINN.docx", true);
    //     var document = doc.MainDocumentPart.Document;
    //
    //     if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Inn Result 1")) != null)
    //     {
    //         ReplaceInnTextTestCase("Inn Result 1", validationResult, document);
    //     }
    //     else if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("Inn Result 2")) != null)
    //     {
    //         ReplaceInnTextTestCase("Inn Result 2", validationResult, document);
    //     }
    // }
    //
    // private void ReplaceInnTextTestCase(string replacedText, bool validationResult, Document document)
    // {
    //     foreach (var text in document.Descendants<Text>())
    //     {
    //         if (text.Text.Contains(replacedText))
    //         {
    //             text.Text = text.Text.Replace(replacedText, validationResult ? "Успешно" : "Не успешно");
    //         }
    //     }
    // }
    //
    // private async void GetInnFromApi_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var httpClient = new HttpClient();
    //     var content = await httpClient.GetStringAsync("http://localhost:4444/TransferSimulator/inn");
    //     var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
    //     InnFromApi = data["value"];
    //     InnFromApiTBlock.Text = InnFromApi;
    // }
    
    //// Обработчик Паспорт
    // private void SendIdentityCardTestResult_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var pattern = @"^\d{2}\s\d{2}\s\d{6}$";
    //     var validationResult = Regex.IsMatch(IdentityCardFromApi, pattern);
    //     IdentityCardValidationResultTBlock.Text = validationResult ? "Номер удостоверения личности корректен" : "Номер удостоверения личности некорректен";
    //
    //     using var doc = WordprocessingDocument.Open(@"TestCaseIdentityCard.docx", true);
    //     var document = doc.MainDocumentPart.Document;
    //
    //     if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("IdentityCard Result 1")) != null)
    //     {
    //         ReplaceIdentityCardTextTestCase("IdentityCard Result 1", validationResult, document);
    //     }
    //     else if (document.Descendants<Text>().FirstOrDefault(text => text.Text.Contains("IdentityCard Result 2")) != null)
    //     {
    //         ReplaceIdentityCardTextTestCase("IdentityCard Result 2", validationResult, document);
    //     }
    // }
    //
    // private void ReplaceIdentityCardTextTestCase(string replacedText, bool validationResult, Document document)
    // {
    //     foreach (var text in document.Descendants<Text>())
    //     {
    //         if (text.Text.Contains(replacedText))
    //         {
    //             text.Text = text.Text.Replace(replacedText, validationResult ? "Успешно" : "Не успешно");
    //         }
    //     }
    // }
    //
    // private async void GetIdentityCardFromApi_OnClick(object? sender, RoutedEventArgs e)
    // {
    //     var httpClient = new HttpClient();
    //     var content = await httpClient.GetStringAsync("http://localhost:4444/TransferSimulator/identityCard");
    //     var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
    //     IdentityCardFromApi = data["value"];
    //     IdentityCardFromApiTBlock.Text = IdentityCardFromApi;
    // }
}
