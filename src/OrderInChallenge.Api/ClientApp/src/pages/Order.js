import React, { Component } from "react";
import { debounce } from "lodash";
import { Container, List, Divider } from 'semantic-ui-react'
import Restaurant from "../components/Restaurant";
import Search from "../components/Search";
import dataService from '../services/dataService'


export default class Order extends Component {
  constructor(props) {
    super(props);
    this.state = {
      search: "",
      restaurants: [],
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

  onButtonClicked = (id1, id2) => {
    console.log(`Restaurant selected ${id1} ${id2}`);
  };

  render() {
    const { restaurants, loading, search } = this.state;
    return (
      
      <Container>
        <Search type="text" value={search} onSearchChange={this.onSearchChanged}/>
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
