import React from "react";
import { Link } from "react-router-dom";

const Navbar = () => {
  return (
    <nav className="bg-blue-600 p-4 text-white">
      <ul className="flex space-x-4">
        <li><Link to="/">Dashboard</Link></li>
        <li><Link to="/dentistas">Dentistas</Link></li>
        <li><Link to="/pacientes">Pacientes</Link></li>
        <li><Link to="/diagnosticos">Diagnósticos</Link></li>
        <li><Link to="/procedimentos">Procedimentos</Link></li>
      </ul>
    </nav>
  );
};

export default Navbar;
