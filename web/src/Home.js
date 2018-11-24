import React, {Component} from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import {Link} from 'react-router-dom'

const styles = theme => ({
    home: {
        backgroundColor: theme.palette.secondary.dark
    },
    logo: {
        height: '10vmin',
        width: '10vmin',
        border: '' + theme.palette.primary.dark + ' solid 1vmin',
        margin: 'auto'
    },
    button: {
        margin: theme.spacing.unit,
    }
});


class Home extends Component {

    render() {
        const {classes} = this.props;
        return (
            <div>
                <div className={classes.logo}></div>
                <Link to='/gallery'>
                <Button variant="contained" color="primary" className={classes.button}>
                    Get Started!
                </Button>
                </Link>
            </div>
        );
    }
}


Home.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Home);