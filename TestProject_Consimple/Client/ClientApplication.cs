using System;
using System.Collections.Generic;
using TestProject_Consimple.View;
using TestProject_Consimple.Models;

namespace TestProject_Consimple.Client
{
    internal class ClientApplication
    {
        private const ConsoleKey _keyToContinue = ConsoleKey.Enter;
        private IDataHttpClient _httpClient;
        private IDataProcessor _dataProcessor;
        private readonly IUserInteraction _interaction;

        public ClientApplication(IDataHttpClient client, IDataProcessor dataProcessor, IUserInteraction interaction)
        {
            this._httpClient = client;
            this._dataProcessor = dataProcessor;
            this._interaction = interaction;
        }

        public void Start()
        {

            BaseModel recievedData = GetData();
            List<Tuple<string, string>> sortedData = CreateDataTable(recievedData);
            PrintTable(sortedData);
            ExitOrRestartDialog(MessageTemplates.exitOrRestartMessage);
        }

        private BaseModel GetData()
        {
            return this._httpClient.GetProducts();
        }

        private List<Tuple<string, string>> CreateDataTable(BaseModel model)
        {
            return this._dataProcessor.CreateTable(model);
        }

        private void PrintTable(List<Tuple<string, string>> sortedData)
        {
            this._interaction.ShowResponse(MessageTemplates.tableHeaders);

            foreach (Tuple<string, string> row in sortedData)
            {
                this._interaction.PrintTable(row.Item1, row.Item2);
            }
        }

        private void ExitOrRestartDialog(string message)
        {
            ConsoleKey userKey = GetUserKey(message);

            if (userKey == _keyToContinue)
            {
                Start();
                return;
            }

            this._interaction.ShowResponse(MessageTemplates.byeMessage);
        }

        private ConsoleKey GetUserKey(string message)
        {
            return this._interaction.GetUserKey(message);
        }
    }
}
