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
        private readonly IUserInteraction _interaction;

        public ClientApplication(IDataHttpClient client, IUserInteraction interaction)
        {
            this._httpClient = client;
            this._interaction = interaction;
        }

        public void Start()
        {
            BaseModel recievedData = GetData();
            string result = CreateDataTable(recievedData);
            PrintTable(result);
            ExitOrRestartDialog(MessageTemplates.exitOrRestartMessage);
        }

        private BaseModel GetData()
        {
            return this._httpClient.GetProducts();
        }

        private string CreateDataTable(BaseModel model)
        {
            return model.ToString();
        }

        private void PrintTable(string table)
        {
            this._interaction.ShowResponse(MessageTemplates.tableHeaders);

            this._interaction.ShowResponse(table);
            
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
