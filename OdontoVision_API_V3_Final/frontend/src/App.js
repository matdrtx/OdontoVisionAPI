import React from "react";
import { Routes, Route } from "react-router-dom";
import Dentistas from "./pages/Dentistas";
import Pacientes from "./pages/Pacientes";
import Diagnosticos from "./pages/Diagnosticos";
import Procedimentos from "./pages/Procedimentos";
import Dashboard from "./pages/Dashboard";
import Navbar from "./components/Navbar";
import "./App.css";

function App() {
  return (
    <>
      <Navbar />
      <div className="container mx-auto p-6 bg-gray-100 min-h-screen">
        <h1 className="text-3xl font-bold text-center mb-6 text-blue-600">
          OdontoVision - Gestão Odontológica
        </h1>
        <div className="max-w-5xl mx-auto bg-white p-6 rounded-lg shadow-md">
          <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/dentistas" element={<Dentistas />} />
            <Route path="/pacientes" element={<Pacientes />} />
            <Route path="/diagnosticos" element={<Diagnosticos />} />
            <Route path="/procedimentos" element={<Procedimentos />} />
          </Routes>
        </div>
      </div>
    </>
  );
}

export default App;
