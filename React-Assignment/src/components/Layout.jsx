import React,{useEffect} from 'react'
import '../styleSheets/layout.css'
import Filter from './Filter'
import Hero from './Hero'
import Header from './Header'

import { useSelector,useDispatch } from "react-redux";
import { setFuel, setBudget, fetchFilteredCars } from '../redux/actions/carDataActions.js'


const Layout = () => {
  console.log("layout re-renders.....")

  const dispatch = useDispatch();
  const { filteredCars, fuel, budget, loading } = useSelector((state) => state.carData);

  useEffect(() => {
    console.log("start fetching cars according to filters")
    dispatch(fetchFilteredCars());
    console.log("fetching successfull")
  }, [fuel, budget, dispatch]);

  return (
   <>
    <Header/>
   <div className="layout">
   <Filter/>
   <Hero/>
   </div>
   </>
  )
}

export default Layout