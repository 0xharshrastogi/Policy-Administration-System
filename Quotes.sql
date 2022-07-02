SELECT TOP (1000)
    [Id]
      , [MinBusinessValue]
      , [MaxBusinessValue]
      , [MinPropertyValue]
      , [MaxPropertyValue]
      , [PropertyType]
      , [QuoteValue]
FROM [QuotesDB].[dbo].[QuotesMaster]
-- Insert rows into table 'TableName'
INSERT INTO [QuotesDB].[dbo].[QuotesMaster]
    ( -- columns to insert data into
    [Id], [MinBusinessValue], [MaxBusinessValue],[MinPropertyValue],[MaxPropertyValue],[PropertyType],[QuoteValue]
    )
VALUES
    ( -- first row: values for the columns in the list above
        '625ae91f-1cad-4e6f-1080-08da5b81a0cf', 0, 2, 0, 2, 'FactoryEquipment', 100000
  )
 
 