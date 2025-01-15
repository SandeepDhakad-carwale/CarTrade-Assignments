import React,{useState} from 'react'
import { IoIosArrowDown } from "react-icons/io";
import '../styleSheets/Fuel.css'
import CheckBox from './CheckBox.jsx';

function Fuel({fuelCategories}) {
    const [isOpen,setIsOpen]=useState(0)

    const toggleDropdown=()=>{
        setIsOpen(!isOpen)
    }
  return (
    <div className="container">
      
      <div className="fuelHeading">
                <h3>Fuel</h3>
                <button className={`arrow-btn ${isOpen ? "rotated" : ""}`} onClick={toggleDropdown}><IoIosArrowDown /></button>
            </div>

      <div className={`dropdown-banner ${isOpen ? "open" : ""}`}>
        <div>
      {fuelCategories.map((ele) => (
         <CheckBox key={ele} content={ele} />
      ))}
      </div>

        
        
        </div>
      </div>
     
  )
}

export default Fuel