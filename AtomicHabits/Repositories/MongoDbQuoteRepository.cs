using System.Collections.Generic;
using AtomicHabits.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AtomicHabits.Repositories
{
  public class MongoDbQuoteRepository : IRepo<ViewQuote, int>
  {
    private const string _database = "quotesDb";
    private const string _collection = "quotes";
    private readonly IMongoCollection<Quote> _quotesCollection;
    private readonly FilterDefinitionBuilder<Quote> _filterBuilder = Builders<Quote>.Filter;

    private readonly IMapper<ViewQuote, Quote> _mapper;

    public MongoDbQuoteRepository(IMongoClient mongoClient, IMapper<ViewQuote, Quote> mapper)
    {
      IMongoDatabase database = mongoClient.GetDatabase(_database);
      _quotesCollection = database.GetCollection<Quote>(_collection);
      _mapper = mapper;
    }
    public ViewQuote Add(ViewQuote quote)
    {
      ViewQuote existingQuote = Get(quote.Id);
      if (existingQuote != null)
        return null;
      Quote newQuote = _mapper.ViewModelToModel(quote);
      _quotesCollection.InsertOne(newQuote);
      //Verify that the quote is added
      return Get(quote.Id);
    }

    public ViewQuote Get(int id)
    {
      var filter = _filterBuilder.Eq(quote => quote.Id, id);
      Quote quote = _quotesCollection.Find(filter).SingleOrDefault();
      if (quote == null)
        return null;
      return _mapper.ModelToViewModel(quote);
    }

    public System.Collections.Generic.IEnumerable<ViewQuote> Get()
    {
      List<Quote> quotes = _quotesCollection.Find(new BsonDocument()).ToList();
      return _mapper.ModelToViewModel(quotes);
    }

    public ViewQuote Update(ViewQuote quote)
    {
      var filter = _filterBuilder.Eq(existingQuote => existingQuote.Id, quote.Id);
      _quotesCollection.ReplaceOne(filter, _mapper.ViewModelToModel(quote));
      return Get(quote.Id);
    }

    public void Delete(int id)
    {
      var filter = _filterBuilder.Eq(existingQuote => existingQuote.Id, id);
      _quotesCollection.DeleteOne(filter);
    }
  }
}