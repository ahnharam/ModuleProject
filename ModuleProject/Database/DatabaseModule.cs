using ModuleProject.Database;
using ModuleProject.Interface;
using MySql.Data.MySqlClient;
using Prism.Mvvm;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using System.Data.Common;

public class DatabaseModule : BindableBase
{
    private static readonly Lazy<DatabaseModule> lazy = new Lazy<DatabaseModule>(() => new DatabaseModule());
    public static DatabaseModule Instance => lazy.Value;

    private IDatabaseConnection _dbConnection;
    private readonly object _dbLock = new object();

    public DatabaseModule() { }

    #region DB Setting property
    private string serverIp;
    public string ServerIp
    {
        get { return serverIp; }
        set { SetProperty(ref serverIp, value); }
    }

    private string serverPort;
    public string ServerPort
    {
        get { return serverPort; }
        set { SetProperty(ref serverPort, value); }
    }

    private string database;
    public string Database
    {
        get { return database; }
        set { SetProperty(ref database, value); }
    }

    private string uid;
    public string Uid
    {
        get { return uid; }
        set { SetProperty(ref uid, value); }
    }

    private string pwd;
    public string Pwd
    {
        get { return pwd; }
        set { SetProperty(ref pwd, value); }
    }
    #endregion

    private string _dbcon = string.Empty;

    public void ServerSetting(string serverIp, string database, string uid, string pwd, string serverPort)
    {
        this.serverIp = serverIp;
        this.database = database;
        this.uid = uid;
        this.pwd = pwd;
        this.serverPort = serverPort;

        CheckServerSetting();
        Setup();
    }

    public void CheckServerSetting()
    {
        if (string.IsNullOrWhiteSpace(ServerIp))
            throw new DatabaseConnectionException("Server IP cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(Database))
            throw new DatabaseConnectionException("Database name cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(Uid))
            throw new DatabaseConnectionException("User ID cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(Pwd))
            throw new DatabaseConnectionException("Password cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(ServerPort))
            throw new DatabaseConnectionException("Server port cannot be null or empty.");
    }

    public void Setup()
    {
        _dbcon = $"SERVER = {ServerIp};" +
            $" DATABASE = {Database};" +
            $" UID = {Uid}; PWD = {Pwd};" +
            $" PORT = {ServerPort};" +
            $" Charset=utf8; Pooling=true; SslMode=none; convert zero datetime=True";
        DatabaseConnection databaseConnection = new DatabaseConnection(_dbcon);
        _dbConnection = databaseConnection;
    }

    public bool Connect()
    {
        bool connected = false;
        try
        {
            _dbConnection.Open();
            connected = true;
        }
        catch (DatabaseConnectionException ex)
        {
            Debug.WriteLine($"General Error: {ex.Message}");
        }
        return connected;
    }

    public async Task<DataTable> SelectAsync(string sql)
    {
        if (_dbConnection.Connection == null)
        {
            Debug.WriteLine("Connection object is null");
            return null;
        }

        try
        {
            lock (_dbLock)
            {
                if (_dbConnection.Connection.State == ConnectionState.Closed)
                {
                    Debug.WriteLine("DB Connection Closed");
                    if (!Connect())
                    {
                        Debug.WriteLine("Database Reconnection Failed");
                        return null;
                    }
                }
            }

            Debug.WriteLine("sql : " + sql);

            using (var command = new MySqlCommand(sql, _dbConnection.Connection))
            {
                using (var adapter = new MySqlDataAdapter(command))
                {
                    DataTable table = new DataTable();
                    await Task.Run(() => adapter.Fill(table));
                    return table;
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine("Select Error : " + e);
            return null;
        }
    }

    public async Task InsertOrUpdateAsync(string sql)
    {
        Debug.WriteLine("Database Insert Data : " + sql);
        lock (_dbLock)
        {
            if (_dbConnection.Connection.State == ConnectionState.Closed)
            {
                Debug.WriteLine("Database Inserting Error, Database Connection is Closed");

                if (!Connect())
                {
                    Debug.WriteLine("Database Reconnection Failed");
                    return;
                }
            }

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, _dbConnection.Connection))
                {
                    int insertCheck = cmd.ExecuteNonQuery();

                    if (insertCheck != -1)
                    {
                        Debug.WriteLine("Insert Complete");
                    }
                    else
                    {
                        Debug.WriteLine("Database Can't Insert");
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Database Insert Exception :" + e);
            }
        }
        await Task.Delay(100);
    }

    public void Disconnect()
    {
        try
        {
            _dbConnection.Close();
        }
        catch (DatabaseConnectionException e)
        {
            Debug.WriteLine("DB Disconnected Error : " + e);
        }
    }
}
