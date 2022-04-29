/* eslint-disable no-restricted-globals */
/* eslint-disable react/style-prop-object */
import React, { useState } from "react";
import "./App.css";
import SecondArray from "./components/secondArray/SecondArray";
import TableItem from "./components/TableItem/TableItem";

const App = (props) => {
  const [task2, setTask2] = useState([
    {
      id: 1,
      name: "Антон",
      secondName: "Хоміцький",
      salary: "20000",
      gender: "Чоловіча",
    },
    {
      id: 2,
      name: "Роман",
      secondName: "Попюк",
      salary: "15000",
      gender: "Чоловіча",
    },
    {
      id: 3,
      name: "Сергій",
      secondName: "Вакуров",
      salary: "10000",
      gender: "Чоловіча",
    },
  ]);

  const [secondArray, setSecondArray] = useState([
    {
      id: 1,
      name: "Молоко",
      price: "200",
      count: "60",
    },
    {
      id: 2,
      name: "Сметана",
      price: "60",
      count: "90",
    },
    {
      id: 3,
      name: "Сік",
      price: "48",
      count: "80",
    },
  ]);

  const [secondArrayName, setSecondArrayName] = useState("");
  const [secondArrayPrice, setSecondArrayPrice] = useState("");
  const [secondArrayCount, setSecondArrayCount] = useState("");

  const showMessage = (string, id) => {
    alert(`Ім'я: ${string}, id: ${id}`);
  };

  const deleteUser = (id) => {
    setTask2(task2.filter((item) => item.id !== id));
  };

  const deleteItemFromArray = (id) => {
    setSecondArray(secondArray.filter((item) => item.id !== id));
  };

  const handleChange = (event) => {
    event.preventDefault();
    setSecondArray([
      ...secondArray,
      {
        id: secondArray[secondArray.length - 1].id + 1,
        name: secondArrayName,
        price: secondArrayPrice,
        count: secondArrayCount,
      },
    ]);
  };

  return (
    <div className="container">
      <div className="item">
        <table className="table">
          <tr>
            <td>Ім'я</td>
            <td>Фамілія</td>
            <td>ЗП</td>
            <td>Стать</td>
            <td>Show message</td>
            <td>Delete user</td>
          </tr>
          <TableItem
            arrayList={task2}
            alertFunction={showMessage}
            deleteUser={deleteUser}
          />
        </table>
      </div>
      <div className="item">
        <SecondArray
          arrayList={secondArray}
          deleteItem={deleteItemFromArray}
          handleChange={handleChange}
          setSecondArrayName={setSecondArrayName}
          setSecondArrayPrice={setSecondArrayPrice}
          setSecondArrayCount={setSecondArrayCount}
        />
      </div>
    </div>
  );
};

export default App;
