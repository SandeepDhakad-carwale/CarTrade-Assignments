import sortCars from "../../utils/sort";

export const setFuel = (fuel) => {
    return {
      type: "SET_FUEL",
      payload: fuel,
    };
  };
  
  export const setBudget = (budget) => {
    return {
      type: "SET_BUDGET",
      payload: budget,
    };
  };
  export const setfilteredCars=(filteredCars)=>{
    return{
      type:"SET_CARS",
      payload:filteredCars
    }
  }

  export const setSortBy=(sortBy)=>{
      return{
        type:"SET_SORTBY",
        payload:sortBy
      }
  }
  
  export const fetchFilteredCars = () => async (dispatch, getState) => {
    const { fuel, budget,sortBy } = getState().carData; 
    dispatch({ type: "FETCH_CARS_REQUEST" });
  
    try {
        const url = `https://stg.carwale.com/api/stocks?fuel=${fuel.join("+")}&budget=${budget.start}-${budget.end}`;

      const response = await fetch(url);
      const data = await response.json();
      // console.log("data :",data.stocks)
      const cars=data.stocks;
      console.log("cars :",cars)
      const sortedData=sortCars(cars,sortBy);
      console.log("sortedcars :",sortedData)
      dispatch({ type: "FETCH_CARS_SUCCESS", payload:sortedData});
    } catch (error) {
      console.log("error in fetching data :",error);
    }
  };
  