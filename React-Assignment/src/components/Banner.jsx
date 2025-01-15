import React, { useEffect, useState } from "react";
import '../styleSheets/Banner.css'
import BudgetBtn from './BudgetBtn';
import { IoIosArrowDown } from "react-icons/io";
import { useSelector,useDispatch } from 'react-redux'
import { setBudget } from '../redux/actions/carDataActions.js'

const Banner =  ({budgetRange}) => {
    console.log("Banner re-renders....")
  const [isOpen, setIsOpen] = useState(0);
  const [customizeOpen,setCustomizeOpen]=useState(0);

  const {budget} = useSelector((state) => state.carData);
  const [start,setStart]=useState(budget.start);
  const [end,setEnd]=useState(budget.end);
  
 const dispatch = useDispatch();
 
 

  const toggleDropdown = () => {
    setIsOpen(p=>!p);
  };

    const handleBlur=(e)=>{
        dispatch(setBudget({start,end}))
    }
  

  return (
    <div className="container">
      
      <div className="budgetHeading">
                <h3>Budget (Lakh)</h3>
                <button className={`arrow-btn ${isOpen ? "rotated" : ""}`} onClick={toggleDropdown}><IoIosArrowDown /></button>
            </div>

      <div className={`dropdown-banner ${isOpen ? "open" : ""}`}>
        <div>
      {budgetRange.map((ele) => (
        <BudgetBtn key={ele.content} content={ele.content} range={ele.range} setStart={setStart} setEnd={setEnd}/>
      ))}
      </div>
     

      <div className="customizeBtn" onClick={()=>{setCustomizeOpen(1)}} >Customize Your Budget</div>
      <div className={`${customizeOpen?"customize-open":"customize"}`}>
        <div className="budget-input">
        <input type="number" value={start} onChange={(e)=>{setStart(e.target.value)}} onBlur={handleBlur}/>
        <h2>-</h2>
        <input type="number" value={end} onChange={(e)=>{setEnd(e.target.value)}} onBlur={handleBlur} />
        
        
        </div>
        <div className="error">{(Number(start) > Number(end)) && "enter valid input"}</div>
      </div>
      </div>
      </div>
  );
}

export default Banner;
