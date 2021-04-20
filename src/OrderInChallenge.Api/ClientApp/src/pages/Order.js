import React, { Component } from "react";
import { debounce } from "lodash";
import { Container, List, Divider, Button, Grid } from 'semantic-ui-react'
import { toast } from 'react-semantic-toasts';
import Restaurant from "../components/Restaurant";
import Search from "../components/Search";
import dataService from '../services/dataService'


export default class Order extends Component {
  constructor(props) {
    super(props);
    this.state = {
      search: "",
      restaurants: [],
      orderItems: [],
      loading: false,
    };
  }

  componentDidMount() {
    this.setState({ loading: true });
    dataService.getAllRestaurants()
      .then((data) => {
        this.setState({ restaurants: [...data] });
      })
      .finally(() => {
        this.setState({ loading: false });
      });
  }

  makeSearch = debounce(() => {
    this.setState({ loading: true });    
    dataService.getAllRestaurantsBySearchKey(this.state.search)
      .then((data) => {
        this.setState({ restaurants: [...data] });
      })
      .finally(() => {
        this.setState({ loading: false });
      });
  }, 1000);

  onSearchChanged = (e) => {
    this.setState({ search: e.target.value });
    this.makeSearch();
  };

  onButtonClicked = (restaurantId, menuItem) => {
    const {orderItems} = this.state;
    if(orderItems.some(oi => oi.restaurantId === restaurantId)){
      const existedOrderItem = orderItems.find(oi => oi.restaurantId === restaurantId);

      if(existedOrderItem.menuItems.some(m => m.id === menuItem.id)){
        existedOrderItem.menuItems = [...existedOrderItem.menuItems.filter(m => m.id !== menuItem.id)];
           
        if(!existedOrderItem.menuItems.length) {
          this.setState({orderItems: [...orderItems.filter(oi => oi.restaurantId !== restaurantId)]});
          return;
        }
      } else {
        existedOrderItem.menuItems = [...existedOrderItem.menuItems, menuItem];
      }
      this.setState({orderItems: [...orderItems.filter(oi => oi.restaurantId !== restaurantId), existedOrderItem]});
    } else {
      this.setState({orderItems: [...orderItems,{restaurantId, menuItems: [menuItem]}]});
    }
    console.log(`Restaurant selected ${this.state.orderItems}`);
  };

  onOrderClick = () => {
    this.setState({ loading: true });    
    dataService.CreateOrder({orderItems: this.state.orderItems})
      .then((data) => {
        toast({
          type: 'success',
          title: 'Success',
          description:  "Your order has been Placed! Leave the rest up to the chefs and our drivers!",
          time: 10000
        });
      })
      .finally(() => {
        this.setState({ loading: false, orderItems: [] });
      });
  }

  render() {
    const { restaurants, loading, search, orderItems } = this.state;
    return (
      
      <Container>
        <Grid>
          <Grid.Column width={4}>
            <Search type="text" value={search} onSearchChange={this.onSearchChanged}/>
          </Grid.Column>
          <Grid.Column width={4}>
            <Button disabled={!orderItems.length} onClick={this.onOrderClick} primary>Order</Button>
          </Grid.Column>
        </Grid>
        <h1>Restaurants</h1>
        {loading ? (
          <div>Loading...</div>
        ) : (
          restaurants.map((x, i) => (
            <div>
              <List>
                <Restaurant key={i} {...x} onItemSelected={this.onButtonClicked} />
              </List>
              <Divider />
            </div>
          ))
        )}
      </Container>
    );
  }
}
