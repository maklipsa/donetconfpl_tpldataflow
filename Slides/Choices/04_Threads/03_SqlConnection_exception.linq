<Query Kind="Expression" />

///
// 										   Rozwiązania
///
//								Zrównoleglenie na poziomie wątków
///
/// 							   	   	  SqlConnection
///
///			System.InvalidOperationException
///			SqlConnection does not support parallel transactions.
///				at System.Data.SqlClient.SqlInternalConnection.BeginSqlTransaction(IsolationLevel iso, String transactionName)
///				at System.Data.SqlClient.SqlConnection.BeginTransaction(IsolationLevel iso, String transactionName)
///
///
///
///										