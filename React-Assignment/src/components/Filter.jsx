import React from 'react'
import '../styleSheets/Filter.css'
import { CiFilter } from "react-icons/ci";

import CheckBox from './CheckBox';
import Banner from './Banner';
import Fuel from './Fuel';

import { useDispatch } from "react-redux";
import { setFuel, setBudget, fetchFilteredCars } from '../redux/actions/carDataActions.js'

const Filter = () => {
    console.log("Filter re-renders...")

     const dispatch=useDispatch();
    const handleClearAll=()=>{
      window.location.reload();
    }

     const checkboxOptions=[{content:"CarWale abSure",inactive:true},{content:"Certified Cars", inactive:true},{content:"Quality Report Available", inactive:true},{content:"Luxury Cars", inactive:true}]
    const budgetRange=[{content:"Below ₹ 3 Lakh",range:[0,3]},{content:"₹ 3-5 Lakh",range:[3,5]},{content:"₹ 5-8 Lakh",range:[5,8]},{content:"₹ 8-12 Lakh",range:[8,12]},{content:"₹ 12-20 Lakh",range:[12,20]},{content:"₹ 20 Lakh+",range:[20,99]}]
    const fuelCategories=["Petrol","Diesel","Cng","Lpg","Electric","Hybrid"]



  return (
    <div className='filterContainer'>
        <div className="filterHeading">
            <div className="left">
            <div className="icon"><CiFilter size={25}/></div>
            <h2>Filters</h2>
            </div>
            <div className="right">  <p className='clearAll' onClick={handleClearAll}>Clear All</p></div>
           
        </div>
        <form className='filterForm'>
            <div className="checkboxs">
               
               { checkboxOptions.map((ele,index)=>  <CheckBox key={index} content={ele.content} inactive={ele.inactive} amount={ele.amount}/>)}
               
                       {/* here i use index as a key because i keep my array (CheckBox) static  */}
              
            </div>

                       {/* // dout here why parents re-renders when i use banner component inside upper form */}
        </form>
        <div className="budgetContainer">
             <Banner budgetRange={budgetRange} /> 
             </div>
                 
    <div className="fuelContainer">
        <Fuel fuelCategories={fuelCategories}/>
    </div>
       
    </div>
    
  )
}

export default Filter