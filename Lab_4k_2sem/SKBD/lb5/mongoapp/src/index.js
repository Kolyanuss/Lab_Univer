const MongoClient = require("mongodb").MongoClient;
const uri = "mongodb://localhost:27017";

const bd_name = "sskbd_facultativ";
const collection_names = ["predmets", "students", "syllabus"];

const client = new MongoClient(uri);
// const client = new MongoClient(uri, {
//   useNewUrlParser: true,
//   useUnifiedTopology: true,
// });

client.connect((err) => {
  const collection = client.db(bd_name).collection(collection_names[0]);
  // perform actions on the collection object

  collection.insertOne(
    {
      name: "test",
      lecturesize: 1,
      practicesize: 2,
      labsize: 3,
    },
    (err, result) => {
      if (err) throw err;
      console.log(result);
    }
  );

  client.close();
});
